using System;

namespace FakeBand.Utils
{
    public static class RandomNormal
    {
        public static double NextNormal(this Random rand, double mean, double stdev)
        {
            var v1 = rand.NextDouble();
            var v2 = rand.NextDouble();

            var rnd = Math.Sqrt(-2.0 * Math.Log(v1)) * Math.Sin(2.0 * Math.PI * v2);
            return mean + stdev * rnd;
        }
    }
}
