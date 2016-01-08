using FakeBand.Fakes;
using Microsoft.Band;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FakeBand.Tests.Utils
{
    public static class TestUtils
    {
        public static async Task<IBandClient> GetBandClientAsync()
        {
            FakeBandClientManager.Configure(new FakeBandClientManagerOptions
            {
                Bands = new List<IBandInfo>
                {
                    new FakeBandInfo(BandConnectionType.Bluetooth, "Fake Band 1"),
                },
                UseUnitTestInterval = true,
                UnitTestSensorInterval = TimeSpan.FromMilliseconds(100),
            });

            var bands = await FakeBandClientManager.Instance.GetBandsAsync();
            var bandInfo = bands.First();
            var bandClient = await FakeBandClientManager.Instance.ConnectAsync(bandInfo);

            return bandClient;
        }

        public static async Task TimeoutAfter(this Task task, int millisecondsTimeout)
        {
            if (task == await Task.WhenAny(task, Task.Delay(millisecondsTimeout)))
                await task;
            else
                throw new TimeoutException();
        }
    }
}
