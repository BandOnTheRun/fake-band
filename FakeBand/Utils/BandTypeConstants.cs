using System;
using System.Diagnostics.CodeAnalysis;

namespace FakeBand.Utils
{
    public enum BandType
    {
        Unknown,
        Cargo,
        Envoy
    }

    internal class BandTypeConstants
    {
        internal static readonly BandTypeConstants Cargo = new BandTypeConstants(BandType.Cargo);

        internal static readonly BandTypeConstants Envoy = new BandTypeConstants(BandType.Envoy);

        public BandType BandType
        {
            get;
            private set;
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public ushort MeTileWidth
        {
            get
            {
                return 310;
            }
        }

        public ushort MeTileHeight
        {
            get
            {
                BandType bandType = this.BandType;
                if (bandType == BandType.Cargo)
                {
                    return 102;
                }
                if (bandType != BandType.Envoy)
                {
                    throw new InvalidOperationException();
                }
                return 128;
            }
        }

        public ushort TileIconPreferredSize
        {
            get
            {
                BandType bandType = this.BandType;
                if (bandType == BandType.Cargo)
                {
                    return 46;
                }
                if (bandType != BandType.Envoy)
                {
                    throw new InvalidOperationException();
                }
                return 48;
            }
        }

        public ushort BadgeIconPreferredSize
        {
            get
            {
                BandType bandType = this.BandType;
                if (bandType == BandType.Cargo)
                {
                    return 24;
                }
                if (bandType != BandType.Envoy)
                {
                    throw new InvalidOperationException();
                }
                return 24;
            }
        }

        public ushort NotificiationIconPreferredSize
        {
            get
            {
                BandType bandType = this.BandType;
                if (bandType == BandType.Cargo)
                {
                    return 36;
                }
                if (bandType != BandType.Envoy)
                {
                    throw new InvalidOperationException();
                }
                return 36;
            }
        }

        public int MaxIconsPerTile
        {
            get
            {
                BandType bandType = this.BandType;
                if (bandType == BandType.Cargo)
                {
                    return 10;
                }
                if (bandType != BandType.Envoy)
                {
                    throw new InvalidOperationException();
                }
                return 15;
            }
        }

        protected BandTypeConstants(BandType bandType)
        {
            this.BandType = bandType;
        }
    }
}
