using FakeBand.Utils;

namespace Microsoft.Band.Tiles
{
    internal static class TileRepresentationExtensions
    {
        public static BandTile ToBandTile(this TileRepresentation representation)
        {
            return new BandTile(representation.Data.AppID)
            {
                IsBadgingEnabled = ((TileSettings)representation.Data.SettingsMask).HasFlag(TileSettings.EnableBadging),
                IsScreenTimeoutDisabled = ((TileSettings)representation.Data.SettingsMask).HasFlag(TileSettings.ScreenTimeoutDisabled),
                Name = representation.Data.FriendlyName,
                TileIcon = representation.Icon
            };
        }
    }
}