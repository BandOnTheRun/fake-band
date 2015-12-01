using Microsoft.Band.Sensors;
using MSBandAzure.Services.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBand.Fakes
{
    public class FakeUVSensor : FakeBandSensor<IBandUVReading>
    {
        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandUVReading();
        }
    }
}
