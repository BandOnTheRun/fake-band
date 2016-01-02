namespace FakeBand.Utils
{
    internal class CargoVersion
    {
        private const int maxAppNameCharCount = 5;

        private const int serializedByteCount = 19;

        public string AppName
        {
            get;
            private set;
        }

        public byte PCBId
        {
            get;
            private set;
        }

        public ushort VersionMajor
        {
            get;
            private set;
        }

        public ushort VersionMinor
        {
            get;
            private set;
        }

        public uint Revision
        {
            get;
            private set;
        }

        public uint BuildNumber
        {
            get;
            private set;
        }

        public byte DebugBuild
        {
            get;
            private set;
        }

        internal static int GetSerializedByteCount()
        {
            return 19;
        }
    }
}