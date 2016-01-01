using Microsoft.Band.Sensors;

namespace MSBandAzure.Services.Fakes
{
    internal class FakeDeviceContactSensor : FakeContactSensor
    {
        public override IBandContactReading CreateReading()
        {
            return new FakeBandDeviceContactReading(BandContactState.Worn);
        }
    }
}