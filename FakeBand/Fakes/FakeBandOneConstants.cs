using System;
using FakeBand.Utils;

namespace FakeBand.Fakes
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