using FakeBand.Utils;

namespace FakeBand.Fakes
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