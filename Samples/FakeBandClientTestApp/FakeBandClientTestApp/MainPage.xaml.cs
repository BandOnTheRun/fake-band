using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Microsoft.Band;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FakeBandClientTestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static readonly public string LabelPostfix = ": ";

        public MainPage()
        {
            // Use static codegen methods to generate ViewModels from the data delivered in the 
            // sensor callbacks
            // Also generate chunks of XAML based on the Viewmodela
            // Note. not intended to run as part of the app.
            //var str = CodeGen.GenerateXamlFromClass(new BandDeviceContactViewModel());
            //str = CodeGen.GenerateXamlFromClass(new GsrViewModel());

            //var vmStr = CodeGen.GenerateViewModelCode(new FakeAccelerometerReading(0, 0, 0));

            //vmStr = CodeGen.GenerateViewModelCode(new FakeGsrReading (1));
            //vmStr = CodeGen.GenerateViewModelCode(new FakeGyroReading(0.0, 0.0, 0.0, 0.0, 0.0, 0.0));

            this.InitializeComponent();
            Loaded += OnLoad;
        }

        private async void OnLoad(object sender, RoutedEventArgs e)
        {
            // Set up the fake bands 
            FakeBandClientManager.Configure(new FakeBandClientManagerOptions
            {
                Bands = new List<IBandInfo>
                {
                    new FakeBandInfo(BandConnectionType.Bluetooth, "Fake Band 1"),
                    new FakeBandInfo(BandConnectionType.Bluetooth, "Fake Band 2"),
                }
            });

            // Use the fake band client manager
            IBandClientManager clientManager = FakeBandClientManager.Instance;

            // Microsoft Band SDK code
            var bands = await clientManager.GetBandsAsync();
            var bandInfo = bands.First();

            var bandClient = await FakeBandClientManager.Instance.ConnectAsync(bandInfo);

            var meTile = await bandClient.PersonalizationManager.GetMeTileImageAsync();
            PersonalizationView.PersonalizationViewModel.MeTile = meTile.ToWriteableBitmap();

            var theme = await bandClient.PersonalizationManager.GetThemeAsync();
            Mapper.Map(theme, ThemeView.BandThemeViewModel);

            await StartSensor(bandClient, bandClient.SensorManager.HeartRate, ev =>
            {
                Mapper.Map(ev.SensorReading, HeartRateView.HeartRateViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Altimeter, ev =>
            {
                Mapper.Map(ev.SensorReading, AltimeterView.AltimeterViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.AmbientLight, ev =>
            {
                Mapper.Map(ev.SensorReading, AmbientLightView.AmbientLightViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Accelerometer, ev =>
            {
                Mapper.Map(ev.SensorReading, AccelerometerView.AccelerometerViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Calories, ev =>
            {
                Mapper.Map(ev.SensorReading, CaloriesView.BandCaloriesViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Contact, ev =>
            {
                Mapper.Map(ev.SensorReading, ContactView.BandDeviceContactViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Distance, ev =>
            {
                Mapper.Map(ev.SensorReading, DistanceView.BandDistanceViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.Gsr, ev =>
            {
                Mapper.Map(ev.SensorReading, GsrView.GsrViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.Gyroscope, ev =>
            {
                Mapper.Map(ev.SensorReading, GyroView.GyroViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.Pedometer, ev =>
            {
                Mapper.Map(ev.SensorReading, PedometerView.BandPedometerViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.RRInterval, ev =>
            {
                Mapper.Map(ev.SensorReading, RRIntervalView.BandRRIntervalViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.SkinTemperature, ev =>
            {
                Mapper.Map(ev.SensorReading, SkinTemperatureView.BandSkinTemperatureViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.UV, ev =>
            {
                Mapper.Map(ev.SensorReading, UVView.BandUVViewModel);
            });
        }

        public async Task StartSensor<T>(IBandClient bandClient, IBandSensor<T> sensor, 
            Action<BandSensorReadingEventArgs<T>> action) where T : IBandSensorReading
        {
            var uc = sensor.GetCurrentUserConsent();
            bool isConsented = false;

            if (uc == UserConsent.NotSpecified)
            {
                isConsented = await sensor.RequestUserConsentAsync();
            }

            if (isConsented || uc == UserConsent.Granted)
            {
                sensor.ReadingChanged += async (obj, ev) =>
                {
                    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action(ev));
                };

                await sensor.StartReadingsAsync();
            }
        }
    }
}
