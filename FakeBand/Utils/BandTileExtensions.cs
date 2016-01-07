using Microsoft.Band.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBand.Utils
{
    public static class BandTileExtensions
    {
        internal static TileData ToTileData(this BandTile tile, int startStripOrder, Guid applicationId)
        {
            TileSettings tileSettings = TileSettings.EnableNotification;
            if (tile.IsBadgingEnabled)
            {
                tileSettings |= TileSettings.EnableBadging;
            }
            if (tile.IsScreenTimeoutDisabled)
            {
                tileSettings |= TileSettings.ScreenTimeoutDisabled;
            }
            TileData td = new TileData();
            td.AppID = tile.TileId;
            td.StartStripOrder = (uint)startStripOrder;
            td.ThemeColor = 0u;
            td.SettingsMask = (ushort)tileSettings;
            td.SetNameAndOwnerId(tile.Name, applicationId);
            return td;
        }
    }
}
