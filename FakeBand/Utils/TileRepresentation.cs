using Microsoft.Band.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBand.Utils
{
    internal class TileRepresentation
    {
        public TileData Data
        {
            get;
            private set;
        }

        internal BandIcon Icon
        {
            get;
            private set;
        }

        public TileRepresentation(TileData data, BandIcon icon)
        {
            this.Data = data;
            this.Icon = icon;
        }
    }
}
