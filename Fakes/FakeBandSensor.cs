using Microsoft.Band;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MSBandAzure.Services.Fakes
{
    public abstract class FakeBandSensor<T> : IBandSensor<T> where T : IBandSensorReading
    {
        public FakeBandSensor()
        {

        }
        public bool IsSupported
        {
            get
            {
                return true;
            }
        }

        public TimeSpan ReportingInterval
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<TimeSpan> SupportedReportingIntervals
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public event EventHandler<BandSensorReadingEventArgs<T>> ReadingChanged;

        public UserConsent GetCurrentUserConsent()
        {
            return UserConsent.Granted;
        }

        public Task<bool> RequestUserConsentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RequestUserConsentAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        IDisposable _subscription;

        public Task<bool> StartReadingsAsync()
        {
            return Task.Run(new Func<bool>(Subscribe));
        }

        public abstract IBandSensorReading CreateReading();

        private bool Subscribe()
        {
            // use an rx observable to simulate the sensor
            var obs = Observable.Interval(TimeSpan.FromSeconds(1));
            _subscription = obs.Subscribe(l =>
            {
                var rc = ReadingChanged;
                if (rc == null)
                    return;

                var t = (T)CreateReading();

                //var t = (T)((IBandSensorReading)(new FakeBandHeartRateReading()));
                BandSensorReadingEventArgs<T> e = new BandSensorReadingEventArgs<T>(t);
                rc(this, e);
            });
            return true;
        }

        public Task<bool> StartReadingsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
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
