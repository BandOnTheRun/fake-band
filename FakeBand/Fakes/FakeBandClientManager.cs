using Microsoft.Band;
using FakeBand.Fakes;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeBand.Fakes
{
    public class FakeBandClientManager : IBandClientManager
    {
        public FakeBandClientManager()
        {

        }

        private static FakeBandClientManager _instance;

        public static IBandClientManager Instance
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

        public static void Configure(FakeBandClientManagerOptions options)
        {
            Bands = options.Bands;
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
    }

    public class FakeBandClientManagerOptions
    {
        public IEnumerable<IBandInfo> Bands { get; set; }
    }
}
