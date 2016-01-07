using Microsoft.Band.Sensors;
using FakeBand.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeBand.Fakes
{
    public class FakeDistanceSensor : FakeBandSensor<IBandDistanceReading>
    {
        Random rand = new Random();

        public override IBandSensorReading CreateReading()
        {
            return new FakeBandDistanceReading();
        }
    }

}
