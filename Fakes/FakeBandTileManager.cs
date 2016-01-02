using FakeBand;
using FakeBand.Utils;
using Microsoft.Band.Tiles;
using Microsoft.Band.Tiles.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandTileManager : IBandTileManager
    {
        internal IBandConstants _constants;

        internal FakeBandTileManager(IBandConstants constants)
        {
            _constants = constants;
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
            var appId = new Guid("C7600DBA-0220-4866-A7BA-08B23C2225C8"); // TODO: Fix this - all this to be configured

            // store that against the tile...
            var tr = new TileRepresentation(tile.ToTileData(_installedTiles.Count, appId), null);
            _installedTiles.Add(tr);

            return true;
        }

        List<TileRepresentation> _installedTiles = new List<TileRepresentation>();

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
                return _installedTiles.Select(tr => tr.ToBandTile());
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
                var bandTile = _installedTiles.Where(t => t.Data.AppID == tileId).FirstOrDefault();
                _installedTiles.Remove(bandTile);
            }, token);

            return true;
        }

        public async Task<bool> RemoveTileAsync(BandTile tile, CancellationToken token)
        {
            await Task.Run(() =>
            {
                var bandTile = _installedTiles.Where(t => t.Data.AppID == tile.TileId).FirstOrDefault();
                _installedTiles.Remove(bandTile);
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
    }
}
