using FakeBand;
using Microsoft.Band.Tiles;
using Microsoft.Band.Tiles.Pages;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandTileManager : IBandTileManager
    {
        public event EventHandler<BandTileEventArgs<IBandTileButtonPressedEvent>> TileButtonPressed;
        public event EventHandler<BandTileEventArgs<IBandTileClosedEvent>> TileClosed;
        public event EventHandler<BandTileEventArgs<IBandTileOpenedEvent>> TileOpened;

        public Task<bool> AddTileAsync(BandTile tile)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddTileAsync(BandTile tile, CancellationToken token)
        {
            if (tile == null)
            {
                throw new ArgumentNullException("tile");
            }
            if (string.IsNullOrWhiteSpace(tile.Name))
            {
                throw new ArgumentException(BandResource.BandTileEmptyName, "tile");
            }
            //if (tile.SmallIcon == null)
            //{
            //    throw new ArgumentException(BandResources.BandTileNoSmallIcon, "tile");
            //}
            //if (tile.TileIcon == null)
            //{
            //    throw new ArgumentException(BandResources.BandTileNoTileIcon, "tile");
            //}
            //this.CheckIfDisposed();
            //this.CheckIfDisconnectedOrUpdateMode();
            //if (tile.AdditionalIcons.Count + 2 > this.BandTypeConstants.MaxIconsPerTile)
            //{
            //    throw new ArgumentException(BandResources.BandTileTooManyIcons, "tile");
            //}
            //if (tile.PageLayouts.Count > 5)
            //{
            //    throw new ArgumentException(BandResources.BandTileTooManyTemplates, "tile");
            //}
            //foreach (PageLayout expr_101 in tile.PageLayouts)
            //{
            //    if (expr_101 == null)
            //    {
            //        throw new InvalidOperationException(BandResources.BandTileNullTemplateEncountered);
            //    }
            //    if (expr_101.GetSerializedByteCountAndValidate() > 768)
            //    {
            //        throw new ArgumentException(BandResources.BandTilePageTemplateBlobTooBig);
            //    }
            //}

            throw new NotImplementedException();
        }

        public Task<int> GetRemainingTileCapacityAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetRemainingTileCapacityAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BandTile>> GetTilesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BandTile>> GetTilesAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePagesAsync(Guid tileId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemovePagesAsync(Guid tileId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTileAsync(Guid tileId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTileAsync(BandTile tile)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTileAsync(Guid tileId, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveTileAsync(BandTile tile, CancellationToken token)
        {
            throw new NotImplementedException();
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
