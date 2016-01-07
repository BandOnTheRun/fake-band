using System;

namespace Microsoft.Band.Tiles
{
    [Flags]
    internal enum TileSettings : ushort
    {
        None = 0,
        EnableNotification = 1,
        EnableBadging = 2,
        UseCustomColorForTile = 4,
        EnableAutoUpdate = 8,
        ScreenTimeout30Seconds = 16,
        ScreenTimeoutDisabled = 32
    }
}
