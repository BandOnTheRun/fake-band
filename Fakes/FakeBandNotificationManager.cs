using FakeBand;
using FakeBand.Utils;
using Microsoft.Band.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandNotificationManager : IBandNotificationManager
    {
        private IAppIdProvider _appIdProvider;
        private ITileContainer _tiles;

        internal FakeBandNotificationManager(IAppIdProvider appIdProvider, ITileContainer tiles)
        {
            _appIdProvider = appIdProvider;
            _tiles = tiles;
        }
        public async Task SendMessageAsync(Guid tileId, string title, string body, DateTimeOffset timestamp, MessageFlags flags = MessageFlags.None)
        {
            await SendMessageAsync(tileId, title, body, timestamp, flags, CancellationToken.None);
        }

        public async Task SendMessageAsync(Guid tileId, string title, string body, DateTimeOffset timestamp, MessageFlags flags, CancellationToken token)
        {
            if (tileId == Guid.Empty)
            {
                throw new ArgumentException(BandResource.NotificationInvalidTileId, "tileId");
            }
            if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(body))
            {
                throw new ArgumentException(BandResource.NotificationFieldsEmpty);
            }

            await Task.Delay(500);

            var appId = _appIdProvider.GetAppId();
            TileData installedTile = _tiles.GetTile(appId, tileId);

            if (installedTile == null || installedTile.OwnerId != appId)
                throw new Exception("Ownership or Tile invalid");

            return;
        }

        public async Task ShowDialogAsync(Guid tileId, string title, string body)
        {
            await ShowDialogAsync(tileId, title, body, CancellationToken.None); 
        }

        public async Task ShowDialogAsync(Guid tileId, string title, string body, CancellationToken token)
        {
            if (tileId == Guid.Empty)
            {
                throw new ArgumentException(BandResource.NotificationInvalidTileId, "tileId");
            }
            if (string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(body))
            {
                throw new ArgumentException(BandResource.NotificationFieldsEmpty);
            }

            await Task.Delay(300);
            return;
        }

        public async Task VibrateAsync(VibrationType vibrationType)
        {
            await Task.Delay(300);
        }

        public async Task VibrateAsync(VibrationType vibrationType, CancellationToken token)
        {
            await Task.Delay(300, token);
        }
    }
}
