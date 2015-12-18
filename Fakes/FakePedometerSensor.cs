using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Band;
using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    internal class FakePedometerSensor : IBandSensor<IBandPedometerReading>
    {
        public bool IsSupported
        {
            get
            {
                throw new NotImplementedException();
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

        public event EventHandler<BandSensorReadingEventArgs<IBandPedometerReading>> ReadingChanged;

        public UserConsent GetCurrentUserConsent()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RequestUserConsentAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RequestUserConsentAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> StartReadingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> StartReadingsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task StopReadingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task StopReadingsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}