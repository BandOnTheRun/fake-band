using FakeBand.Utils;

namespace MSBandAzure.Services.Fakes
{
    internal class FakeBandTwoConstants : IBandConstants
    {
        public BandTypeConstants BandTypeConstants
        {
            get
            {
                return BandTypeConstants.Envoy;
            }
        }
    }
}