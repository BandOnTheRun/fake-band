using FakeBand.Fakes;
using System;
using System.Text;

namespace FakeBand.Utils
{
    internal class TileData
    {
        private const int serializedByteCount = 88;

        private Guid appID;

        public Guid AppID
        {
            get
            {
                return this.appID;
            }
            set
            {
                this.appID = value;
            }
        }

        public uint StartStripOrder
        {
            get;
            set;
        }

        public uint ThemeColor
        {
            get;
            set;
        }

        public ushort FriendlyNameLength
        {
            get;
            set;
        }

        public ushort SettingsMask
        {
            get;
            set;
        }

        public byte[] NameAndOwnerId
        {
            get;
            set;
        }

        public string FriendlyName
        {
            get
            {
                if (this.NameAndOwnerId != null && this.FriendlyNameLength > 0 && this.NameAndOwnerId.Length >= (int)(this.FriendlyNameLength * 2))
                {
                    return Encoding.Unicode.GetString(this.NameAndOwnerId, 0, (int)(this.FriendlyNameLength * 2));
                }
                return string.Empty;
            }
        }

        public Guid OwnerId
        {
            get
            {
                return FakeBandClient.GetApplicationIdFromName(this.NameAndOwnerId, this.FriendlyNameLength);
            }
        }

        public void SetNameAndOwnerId(string name, Guid ownerId)
        {
            // TODO: - do we need this??
            //if (name != null && name.Length > 29)
            //{
            //    throw new ArgumentException(string.Format(BandResource.GenericLengthExceeded, new object[]
            //    {
            //        "name"
            //    }));
            //}
            //if (name != null && name.Length > 21 && ownerId != Guid.Empty)
            //{
            //    throw new ArgumentException(BandResource.BandTileOwnedTileNameExceedsLength, "name");
            //}
            //byte[] array = new byte[60];
            //if (ownerId != Guid.Empty)
            //{
            //    byte[] array2 = ownerId.ToByteArray();
            //    Array.Copy(array2, 0, array, array.Length - array2.Length, array2.Length);
            //}
            //if (!string.IsNullOrEmpty(name))
            //{
            //    int bytesTrimDanglingHighSurrogate = Encoding.Unicode.GetBytesTrimDanglingHighSurrogate(name, 0, name.Length, array, 0);
            //    this.NameAndOwnerId = array;
            //    this.FriendlyNameLength = (ushort)(bytesTrimDanglingHighSurrogate / 2);
            //    return;
            //}
            //this.NameAndOwnerId = array;
            //this.FriendlyNameLength = 0;
        }

        public static int GetSerializedByteCount()
        {
            return 88;
        }
    }
}
