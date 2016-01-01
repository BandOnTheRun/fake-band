using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Band;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    internal abstract class FakeContactSensor : IBandContactSensor
    {
        private IDisposable _subscription;

        public virtual bool IsSupported
        {
            get { return true; }
        }

        public virtual TimeSpan ReportingInterval
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

        public virtual IEnumerable<TimeSpan> SupportedReportingIntervals
        {
            get { throw new NotImplementedException(); }
        }

        public event EventHandler<BandSensorReadingEventArgs<IBandContactReading>> ReadingChanged;

        public Task<IBandContactReading> GetCurrentStateAsync()
        {
            Task.Delay(300);
            var contactReading = CreateReading();
            return Task.FromResult(contactReading);
        }

        public UserConsent GetCurrentUserConsent()
        {
            Task.Delay(300);
            return UserConsent.Granted;
        }

        public virtual async Task<bool> RequestUserConsentAsync()
        {
            await Task.Delay(300);
            return true;
        }

        public virtual async Task<bool> RequestUserConsentAsync(CancellationToken token)
        {
            await Task.Delay(300, token);
            return true;
        }

        public Task<bool> StartReadingsAsync()
        {
            return Task.Run(new Func<bool>(Subscribe));
        }

        public Task<bool> StartReadingsAsync(CancellationToken token)
        {
            return Task.Run(new Func<bool>(Subscribe), token);
        }

        public Task StopReadingsAsync()
        {
            return Task.Run(new Action(CancelSubscription));
        }

        public Task StopReadingsAsync(CancellationToken token)
        {
            return Task.Run(new Action(CancelSubscription), token);
        }

        public abstract IBandContactReading CreateReading();

        private bool Subscribe()
        {
            // use an rx observable to simulate the sensor
            var obs = Observable.Interval(TimeSpan.FromSeconds(30));
            _subscription = obs.Subscribe(l =>
            {
                var rc = ReadingChanged;
                if (rc == null)
                    return;

                var contactReading = CreateReading();

                BandSensorReadingEventArgs<IBandContactReading> e = new BandSensorReadingEventArgs<IBandContactReading>(contactReading);
                rc(this, e);
            });
            return true;
        }

        private void CancelSubscription()
        {
            if (_subscription == null) return;
            _subscription.Dispose();
            _subscription = null;
        }
    }
}