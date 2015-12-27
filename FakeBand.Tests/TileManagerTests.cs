using FakeBand.Tests.Utils;
using Microsoft.Band.Tiles;
using System.Collections.Generic;
using Xunit;

namespace FakeBand.Tests
{
    public class TileManagerTests
    {
        // retrieve list of tiles on band
        // determine if there is space for more tiles
        // create a new tile
        // remove all apps tiles...

        [Fact]
        public async void TileManager_GetTiles()
        {
            var bandClient = await TestUtils.GetBandClientAsync();

            // get the current set of tiles 
            IEnumerable<BandTile> tiles = await bandClient.TileManager.GetTilesAsync();

        }
    }
}
