namespace FakeBand.Utils
{
    public enum SubscriptionType : byte
    {
        Accelerometer128MS,
        Accelerometer32MS,
        AccelerometerGyroscope128MS = 4,
        AccelerometerGyroscope32MS,
        Distance = 13,
        Gsr = 15,
        HeartRate,
        Pedometer = 19,
        SkinTemperature,
        UV,
        AmbientLight = 25,
        RRInterval,
        DeviceContact = 35,
        UVFast = 40,
        Calories1S = 46,
        Accelerometer16MS = 48,
        AccelerometerGyroscope16MS,
        Barometer = 58,
        Elevation = 71
    }
}
