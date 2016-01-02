using FakeBand.Utils;
using Microsoft.Band;
using Microsoft.Band.Notifications;
using Microsoft.Band.Personalization;
using Microsoft.Band.Sensors;
using Microsoft.Band.Tiles;
using System.Threading;
using System.Threading.Tasks;

namespace MSBandAzure.Services.Fakes
{
    public enum BandVersion
    {
        BandOne,
        BandTwo,
    };

    public class FakeBandClient : IBandClient
    {
        internal CargoVersions FirmwareVersions
        {
            get;
            private set;
        }

        internal BandTypeConstants BandTypeConstants
        {
            get
            {
                if (this._bandVersion == BandVersion.BandOne)
                {
                    return BandTypeConstants.Cargo;
                }
                return BandTypeConstants.Envoy;
            }
        }
        public IBandNotificationManager NotificationManager
        {
            get
            {
                return new FakeBandNotificationManager();
            }
        }

        public IBandPersonalizationManager PersonalizationManager
        {
            get
            {
                return new FakeBandPersonalizationManager();
            }
        }

        private IBandSensorManager _sensorManager = new FakeBandSensorManager();
        private IBandInfo bandInfo;
        private BandVersion _bandVersion;

        public FakeBandClient(IBandInfo bandInfo, BandVersion version = BandVersion.BandTwo)
        {
            this.bandInfo = bandInfo;
            this._bandVersion = version;
        }

        public IBandSensorManager SensorManager
        {
            get
            {
                return _sensorManager;
            }
        }

        public IBandTileManager TileManager
        {
            get
            {
                return new FakeBandTileManager();
            }
        }

        public void Dispose()
        {
        }

        public async Task<string> GetFirmwareVersionAsync()
        {
            await Task.Delay(200);
            return "1.0.0.0";
        }

        public async Task<string> GetFirmwareVersionAsync(CancellationToken token)
        {
            await Task.Delay(200, token);
            return "1.0.0.0";
        }

        public async Task<string> GetHardwareVersionAsync()
        {
            await Task.Delay(200);
            return "1.0.0.0";
        }

        public async Task<string> GetHardwareVersionAsync(CancellationToken token)
        {
            await Task.Delay(200, token);
            return "1.0.0.0";
        }
    }
}
