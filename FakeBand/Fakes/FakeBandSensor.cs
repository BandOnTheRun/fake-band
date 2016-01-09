using FakeBand.Utils;
using Microsoft.Band;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FakeBand.Fakes
{
    public abstract class FakeBandSensor<T> : IBandSensor<T> where T : IBandSensorReading
    {
        internal FakeBandSensor(IEnumerable<BandType> supportedBandClasses, Dictionary<TimeSpan, SubscriptionType> supportedReportingSubscriptions, BandTypeConstants type)
        {
            _supportedReportingSubscriptions = supportedReportingSubscriptions;
            _isSupported = supportedBandClasses.Contains(type.BandType);
            _reportingInterval = _supportedReportingSubscriptions.Keys.FirstOrDefault();
        }

        private bool _isSupported;
        public virtual bool IsSupported
        {
            get { return _isSupported; }
        }

        private TimeSpan _reportingInterval = TimeSpan.FromSeconds(1);

        public virtual TimeSpan ReportingInterval
        {
            get
            {
                return _reportingInterval;
            }
            set
            {
                if (!_supportedReportingSubscriptions.Keys.Contains(value))
                {
                    throw new ArgumentOutOfRangeException(BandResource.UnsupportedSensorInterval);
                }
                _reportingInterval = value;
            }
        }

        protected Dictionary<TimeSpan, SubscriptionType> _supportedReportingSubscriptions;

        public virtual IEnumerable<TimeSpan> SupportedReportingIntervals
        {
            get
            {
                return _supportedReportingSubscriptions.Keys;
            }
        }

        public event EventHandler<BandSensorReadingEventArgs<T>> ReadingChanged;

        public virtual UserConsent GetCurrentUserConsent()
        {
            return UserConsent.Granted;
        }

        public async virtual Task<bool> RequestUserConsentAsync()
        {
            await Task.Delay(300);
            return true;
        }

        public async virtual Task<bool> RequestUserConsentAsync(CancellationToken token)
        {
            await Task.Delay(300, token);
            return true;
        }

        IDisposable _subscription;

        public Task<bool> StartReadingsAsync()
        {
            return Task.Run(new Func<bool>(Subscribe));
        }

        public abstract IBandSensorReading CreateReading();
        public abstract bool HasReadingChanged(IBandSensorReading newReading);

        private bool Subscribe()
        {
            TimeSpan interval;
            if (FakeBandClientManager.Instance.UnitTesting)
                interval = FakeBandClientManager.Instance.TestSensorInterval;
            else
                interval = ReportingInterval;

            bool ret = false;
            if (interval <= TimeSpan.Zero)
            {
                // Only fire an update if the value has changed (poll for change every second?)
                var obs = Observable.Interval(TimeSpan.FromSeconds(1));
                _subscription = obs.Subscribe(l =>
                {
                    var rc = ReadingChanged;
                    if (rc == null)
                        return;

                    var t = (T)CreateReading();
                    if (!HasReadingChanged(t))
                        return;

                    BandSensorReadingEventArgs<T> e = new BandSensorReadingEventArgs<T>(t);
                    rc(this, e);
                });

                ret = true;
            }
            else
            {
                // use an rx observable to simulate the sensor
                var obs = Observable.Interval(interval);
                _subscription = obs.Subscribe(l =>
                {
                    var rc = ReadingChanged;
                    if (rc == null)
                        return;

                    var t = (T)CreateReading();

                    BandSensorReadingEventArgs<T> e = new BandSensorReadingEventArgs<T>(t);
                    rc(this, e);
                });
                ret = true;
            }
            return ret;
        }

        public Task<bool> StartReadingsAsync(CancellationToken token)
        {
            return Task.Run(new Func<bool>(Subscribe), token);
        }

        private void CancelSubscription()
        {
            if (_subscription != null)
            {
                _subscription.Dispose();
                _subscription = null;
            }
        }

        public Task StopReadingsAsync()
        {
            return Task.Run(new Action(CancelSubscription));
        }

        public Task StopReadingsAsync(CancellationToken token)
        {
            return Task.Run(new Action(CancelSubscription), token);
        }
    }
}
