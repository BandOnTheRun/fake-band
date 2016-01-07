using FakeBand.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using FakeBand.Utils;
using Microsoft.Band.Tiles;

namespace FakeBand.Fakes
{
    internal class FakeTileContainer : ITileContainer
    {
        private List<TileRepresentation> _tiles = new List<TileRepresentation>();

        public void AddTile(TileRepresentation tr)
        {
            _tiles.Add(tr);
        }

        public IEnumerable<BandTile> GetBandTiles()
        {
            return _tiles.Select(tr => tr.ToBandTile());
        }

        public int GetCount()
        {
            return _tiles.Count;
        }

        public TileData GetTile(Guid appId, Guid tileId)
        {
            throw new NotImplementedException();
        }

        public void RemoveTile(BandTile tile)
        {
            var bandTile = _tiles.Where(t => t.Data.AppID == tile.TileId).FirstOrDefault();
            _tiles.Remove(bandTile);
        }

        public void RemoveTile(Guid tileId)
        {
            var bandTile = _tiles.Where(t => t.Data.AppID == tileId).FirstOrDefault();
            _tiles.Remove(bandTile);
        }
    }
}
