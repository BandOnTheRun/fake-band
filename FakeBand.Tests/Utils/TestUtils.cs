using FakeBand.Fakes;
using Microsoft.Band;
using MSBandAzure.Services.Fakes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeBand.Tests.Utils
{
    public class TestUtils
    {
        public static async Task<IBandClient> GetBandClientAsync()
        {
            FakeBandClientManager.Configure(new FakeBandClientManagerOptions
            {
                Bands = new List<IBandInfo>
                {
                    new FakeBandInfo(BandConnectionType.Bluetooth, "Fake Band 1"),
                }
            });

            var bands = await FakeBandClientManager.Instance.GetBandsAsync();
            var bandInfo = bands.First();
            var bandClient = await FakeBandClientManager.Instance.ConnectAsync(bandInfo);

            return bandClient;
        }
    }
}
