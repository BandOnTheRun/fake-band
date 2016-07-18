using FakeBand;
using FakeBand.Utils;
using Microsoft.Band.Tiles;
using Microsoft.Band.Tiles.Pages;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FakeBand.Fakes
{
    public class FakeBandTileManager : IBandTileManager
    {
        internal IBandConstants _constants;

        internal FakeBandTileManager(IBandConstants constants, IAppIdProvider appIdProvider, ITileContainer tiles)
        {
            _constants = constants;
            _appIdProvider = appIdProvider;
            _tiles = tiles;
        }

        public event EventHandler<BandTileEventArgs<IBandTileButtonPressedEvent>> TileButtonPressed;
        public event EventHandler<BandTileEventArgs<IBandTileClosedEvent>> TileClosed;
        public event EventHandler<BandTileEventArgs<IBandTileOpenedEvent>> TileOpened;

        public Task<bool> AddTileAsync(BandTile tile)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddTileAsync(BandTile tile, CancellationToken token)
        {
            if (tile == null)
            {
                throw new ArgumentNullException("tile");
            }
            if (string.IsNullOrWhiteSpace(tile.Name))
            {
                throw new ArgumentException(BandResource.BandTileEmptyName, "tile");
            }
            if (tile.SmallIcon == null)
            {
                throw new ArgumentException(BandResource.BandTileNoSmallIcon, "tile");
            }
            if (tile.TileIcon == null)
            {
                throw new ArgumentException(BandResource.BandTileNoTileIcon, "tile");
            }
            if (tile.AdditionalIcons.Count + 2 > _constants.BandTypeConstants.MaxIconsPerTile)
            {
                throw new ArgumentException(BandResource.BandTileTooManyIcons, "tile");
            }
            if (tile.PageLayouts.Count > 5)
            {
                throw new ArgumentException(BandResource.BandTileTooManyTemplates, "tile");
            }
            foreach (PageLayout layout in tile.PageLayouts)
            {
                if (layout == null)
                {
                    throw new InvalidOperationException(BandResource.BandTileNullTemplateEncountered);
                }
                // TODO: add this back...
                //if (layout.GetSerializedByteCountAndValidate() > 768)
                //{
                //    throw new ArgumentException(BandResource.BandTilePageTemplateBlobTooBig);
                //}
            }

            await Task.Delay(500);

            // We will only run against one app so don't need much complexity here (would be nice at some 
            // point to be able the client to be able to test against a pre-configured setup of app tiles
            // on the band though)

            // request consent from user (TODO: make this a configurable property).
            // generate application ID which identifies the application package
            //var package = System.Windows.ApplicationModel.Package.current;
            var appId = _appIdProvider.GetAppId(); // TODO: Fix this - all this to be configured

            // store that against the tile...
            var tr = new TileRepresentation(tile.ToTileData(_tiles.GetCount(), appId), null);

            _tiles.AddTile(tr);

            return true;
        }

        private IAppIdProvider _appIdProvider;
        private ITileContainer _tiles;

        public Task<int> GetRemainingTileCapacityAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetRemainingTileCapacityAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BandTile>> GetTilesAsync()
        {
            return await GetTilesAsync(CancellationToken.None);
        }

        public async Task<IEnumerable<BandTile>> GetTilesAsync(CancellationToken token)
        {
            return await Task.Run(() =>
            {
                return _tiles.GetBandTiles();
            }, token);
        }

        public Task<bool> RemovePagesAsync(Guid tileId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePagesAsync(Guid tileId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveTileAsync(Guid tileId)
        {
            return await RemoveTileAsync(tileId, CancellationToken.None);
        }

        public async Task<bool> RemoveTileAsync(BandTile tile)
        {
            return await RemoveTileAsync(tile, CancellationToken.None);
        }

        public async Task<bool> RemoveTileAsync(Guid tileId, CancellationToken token)
        {
            await Task.Run(() =>
            {
                _tiles.RemoveTile(tileId);
            }, token);

            return true;
        }

        public async Task<bool> RemoveTileAsync(BandTile tile, CancellationToken token)
        {
            await Task.Run(() =>
            {
                _tiles.RemoveTile(tile);
            }, token);

            return true;
        }

        public Task<bool> SetPagesAsync(Guid tileId, IEnumerable<PageData> pages)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetPagesAsync(Guid tileId, params PageData[] pages)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetPagesAsync(Guid tileId, CancellationToken token, IEnumerable<PageData> pages)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetPagesAsync(Guid tileId, CancellationToken token, params PageData[] pages)
        {
            throw new NotImplementedException();
        }

        public Task StartReadingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task StartReadingsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task StopReadingsAsync()
        {
            throw new NotImplementedException();
        }

        public Task StopReadingsAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public bool TileInstalledAndOwned(Guid tileId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
