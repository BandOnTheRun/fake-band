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

        public Task ShowDialogAsync(Guid tileId, string title, string body)
        {
            throw new NotImplementedException();
        }

        public Task ShowDialogAsync(Guid tileId, string title, string body, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task VibrateAsync(VibrationType vibrationType)
        {
            throw new NotImplementedException();
        }

        public Task VibrateAsync(VibrationType vibrationType, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
