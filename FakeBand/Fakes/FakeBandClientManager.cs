using Microsoft.Band;
using FakeBand.Fakes;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace FakeBand.Fakes
{
    public class FakeBandClientManager : IBandClientManager
    {
        public FakeBandClientManager()
        {

        }

        private static FakeBandClientManager _instance;

        public static FakeBandClientManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FakeBandClientManager();
                }
                return _instance;
            }
        }

        private static bool UseUnitTestInterval { get; set; }

        private static TimeSpan UnitTestSensorInterval { get; set; }

        public bool UnitTesting { get { return UseUnitTestInterval; } }

        public TimeSpan TestSensorInterval { get { return UnitTestSensorInterval; } }

        public static void Configure(FakeBandClientManagerOptions options)
        {
            Bands = options.Bands;
            UseUnitTestInterval = options.UseUnitTestInterval;
            UnitTestSensorInterval = options.UnitTestSensorInterval;
        }

        public async Task<IBandClient> ConnectAsync(IBandInfo bandInfo)
        {
            await Task.Delay(300);
            return new FakeBandClient(bandInfo);
        }

        private static IEnumerable<IBandInfo> Bands;

        public async Task<IBandInfo[]> GetBandsAsync()
        {
            await Task.Delay(300);
            return Bands.ToArray();
        }

        public async Task<IBandInfo[]> GetBandsAsync(bool isBackground)
        {
            await Task.Delay(300);
            return Bands.ToArray();
        }
    }

    public class FakeBandClientManagerOptions
    {
        public IEnumerable<IBandInfo> Bands { get; set; }
        public TimeSpan UnitTestSensorInterval { get; set; }
        public bool UseUnitTestInterval { get; set; }
    }
}
