using System;
using FakeBand.Utils;

namespace MSBandAzure.Services.Fakes
{
    internal class FakeBandOneConstants : IBandConstants
    {
        public BandTypeConstants BandTypeConstants
        {
            get
            {
                return BandTypeConstants.Cargo;
            }
        }
    }
}