using FakeBand.Utils;
using Microsoft.Band;
using Microsoft.Band.Notifications;
using Microsoft.Band.Personalization;
using Microsoft.Band.Sensors;
using Microsoft.Band.Tiles;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace FakeBand.Fakes
{
    public enum BandVersion
    {
        BandOne,
        BandTwo,
    };

    public class FakeBandClient : IBandClient, IAppIdProvider
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
                if (_bandVersion == BandVersion.BandOne)
                {
                    return BandTypeConstants.Cargo;
                }
                return BandTypeConstants.Envoy;
            }
        }

        private Lazy<IBandNotificationManager> _notificationManager;

        public IBandNotificationManager NotificationManager
        {
            get
            {
                return _notificationManager.Value;
            }
        }

        private Lazy<IBandPersonalizationManager> _personalizationManager;

        public IBandPersonalizationManager PersonalizationManager
        {
            get
            {
                return _personalizationManager.Value;
            }
        }

        private Lazy<IBandSensorManager> _sensorManager;
        private IBandInfo bandInfo;
        private BandVersion _bandVersion;

        public FakeBandClient(IBandInfo bandInfo)
        {
            this.bandInfo = bandInfo;
            _bandVersion = ((FakeBandInfo)bandInfo).Version;
            _container = new Lazy<FakeTileContainer>(() => new FakeTileContainer());
            _sensorManager = new Lazy<IBandSensorManager>(() => new FakeBandSensorManager(BandTypeConstants));
            _notificationManager = new Lazy<IBandNotificationManager>(() => new FakeBandNotificationManager(this, Container));
            _personalizationManager = new Lazy<IBandPersonalizationManager>(() => new FakeBandPersonalizationManager());
            _tileManager = new Lazy<IBandTileManager>(() =>
            {
                IBandConstants consts = null;
                if (_bandVersion == BandVersion.BandOne)
                {
                    consts = new FakeBandOneConstants();
                }
                else
                {
                    consts = new FakeBandTwoConstants();
                }

                return new FakeBandTileManager(consts, this, Container);
            });
        }

        internal static Guid GetApplicationIdFromName(byte[] nameAndOwnerId, ushort friendlyNameLength)
        {
            throw new NotImplementedException();
        }

        public IBandSensorManager SensorManager
        {
            get
            {
                return _sensorManager.Value;
            }
        }

        private Lazy<FakeTileContainer> _container;
        private FakeTileContainer Container {  get { return _container.Value; } }

        private Lazy<IBandTileManager> _tileManager;

        public IBandTileManager TileManager
        {
            get
            {
                return _tileManager.Value;
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

        public Guid GetAppId()
        {
            return new Guid("C7600DBA-0220-4866-A7BA-08B23C2225C8"); // TODO: Fix this - all this to be configured..
        }
    }
}
