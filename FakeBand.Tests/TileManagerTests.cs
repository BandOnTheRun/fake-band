using FakeBand.Tests.Utils;
using Microsoft.Band;
using Microsoft.Band.Tiles;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Media.Imaging;
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

        [Fact]
        public async void TileManager_SetNewTile()
        {
            var bandClient = await TestUtils.GetBandClientAsync();

            // create a new Guid for the tile 
            Guid tileGuid = Guid.NewGuid();

            // Create the small and tile icons from writable bitmaps. 
            // Small icons are 24x24 pixels. 
            WriteableBitmap smallIconBitmap = new WriteableBitmap(24, 24);
            BandIcon smallIcon = smallIconBitmap.ToBandIcon();

            // Tile icons are 46x46 pixels for Microsoft Band 1, and 48x48 pixels  
            // for Microsoft Band 2. 
            WriteableBitmap tileIconBitmap = new WriteableBitmap(46, 46);
            BandIcon tileIcon = tileIconBitmap.ToBandIcon();   
            
            // create a new tile 
            BandTile tile = new BandTile(tileGuid)
            {
                // set the name     
                Name = "MyTile",
                
                // set the icons     
                SmallIcon = smallIcon,
                TileIcon = tileIcon
            }; 

            // get the current set of tiles 
            try
            {
                // add the tile to the Band     
                if (await bandClient.TileManager.AddTileAsync(tile))
                {
                    // tile was successfully added          
                    // can proceed to set tile content with SetPagesAsync     
                }
                else
                {
                    // tile failed to be added, handle error     
                }
            }
            catch (BandException ex)
            {     
                // handle a Band connection exception } 

            }
        }
    }
}
