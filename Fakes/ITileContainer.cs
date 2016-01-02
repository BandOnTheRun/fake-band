using System;
using System.Collections.Generic;
using FakeBand.Utils;
using Microsoft.Band.Tiles;

namespace MSBandAzure.Services.Fakes
{
    internal interface ITileContainer
    {
        TileData GetTile(Guid appId, Guid tileId);
        void AddTile(TileRepresentation tr);
        IEnumerable<BandTile> GetBandTiles();
        int GetCount();
        void RemoveTile(Guid tileId);
        void RemoveTile(BandTile tile);
    }
}