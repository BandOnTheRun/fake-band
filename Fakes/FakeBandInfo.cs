using Microsoft.Band;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandInfo : IBandInfo
    {
        BandConnectionType _connType;
        string _name;

        public FakeBandInfo(BandConnectionType connType, string name)
        {
            _connType = connType;
            _name = name;
        }

        public BandConnectionType ConnectionType { get { return _connType; } }

        public string Name { get { return _name; } }
    }
}
