using Microsoft.Band;

namespace FakeBand.Fakes
{
    public class FakeBandInfo : IBandInfo
    {
        BandConnectionType _connType;
        string _name;
        private BandVersion _version;

        public FakeBandInfo(BandConnectionType connType, string name, BandVersion version = BandVersion.BandTwo)
        {
            _connType = connType;
            _name = name;
            _version = version;
        }

        public BandConnectionType ConnectionType { get { return _connType; } }

        public string Name { get { return _name; } }

        public BandVersion Version {  get { return _version; } }
    }
}
