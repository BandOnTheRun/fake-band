using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.ViewModels;
using Microsoft.Band;
using Microsoft.Band.Sensors;
using MSBandAzure.Services.Fakes;
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
        public HeartRateViewModel HeartRateViewModel { get; set; } = new HeartRateViewModel();
        public AltimeterViewModel AltimeterViewModel { get; set; } = new AltimeterViewModel();
        public AmbientLightViewModel AmbientLightViewModel { get; set; } = new AmbientLightViewModel();
        public BandDistanceViewModel BandDistanceViewModel { get; set; } = new BandDistanceViewModel();
        public BandPedometerViewModel BandPedometerViewModel { get; set; } = new BandPedometerViewModel();
        public BandRRIntervalViewModel BandRRIntervalViewModel { get; set; } = new BandRRIntervalViewModel();
        public BandSkinTemperatureViewModel BandSkinTemperatureViewModel { get; set; } = new BandSkinTemperatureViewModel();
        public BandUVViewModel BandUVViewModel { get; set; } = new BandUVViewModel();
        public PersonalizationViewModel PersonalizationViewModel { get; set; } = new PersonalizationViewModel();
        public BandThemeViewModel BandThemeViewModel { get; set; } = new BandThemeViewModel();

        public MainPage()
        {
            // Use static codegen methods to generate ViewModels from the data delivered in the 
            // sensor callbacks
            // Also generate chunks of XAML based on the Viewmodela
            // Note. not intended to run as part of the app.
            //var str = CodeGen.GenerateXamlFromClass(new BandDistanceViewModel());
            //str = GenerateXamlFromClass(new BandPedometerViewModel());
            //str = GenerateXamlFromClass(new BandRRIntervalViewModel());
            //str = GenerateXamlFromClass(new BandSkinTemperatureViewModel());
            //str = GenerateXamlFromClass(new BandUVViewModel());

            //var vmStr = CodeGen.GenerateViewModelCode(new BandTheme());

            //vmStr = GenerateViewModelCode(new FakeBandDistanceReading ());
            //vmStr = GenerateViewModelCode(new FakeBandPedometerReading(0));
            //vmStr = GenerateViewModelCode(new FakeBandRRIntervalReading(0.0));
            //vmStr = GenerateViewModelCode(new FakeBandSkinTemperatureReading(0));
            //vmStr = GenerateViewModelCode(new FakeBandUVReading());

            Mapper.CreateMap<FakeAltimeterReading, AltimeterViewModel>();
            Mapper.CreateMap<FakeBandHeartRateReading, HeartRateViewModel>();
            Mapper.CreateMap<FakeAmbientLightReading, AmbientLightViewModel>();
            Mapper.CreateMap<FakeBandDistanceReading, BandDistanceViewModel>();
            Mapper.CreateMap<FakeBandPedometerReading, BandPedometerViewModel>();
            Mapper.CreateMap<FakeBandRRIntervalReading, BandRRIntervalViewModel>();
            Mapper.CreateMap<FakeBandSkinTemperatureReading , BandSkinTemperatureViewModel>();
            Mapper.CreateMap<FakeBandUVReading, BandUVViewModel>();
            Mapper.CreateMap<BandTheme, BandThemeViewModel>();

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
            PersonalizationViewModel.MeTile = meTile.ToWriteableBitmap();

            var theme = await bandClient.PersonalizationManager.GetThemeAsync();
            Mapper.Map(theme, BandThemeViewModel);

            await StartSensor(bandClient, bandClient.SensorManager.HeartRate, ev =>
            {
                Mapper.Map(ev.SensorReading, HeartRateViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Altimeter, ev =>
            {
                Mapper.Map(ev.SensorReading, AltimeterViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.AmbientLight, ev =>
            {
                Mapper.Map(ev.SensorReading, AmbientLightViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Accelerometer, ev =>
            {
                //Mapper.Map(ev.SensorReading, AltimeterViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Calories, ev =>
            {
                //Mapper.Map(ev.SensorReading, AltimeterViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Contact, ev =>
            {
                //Mapper.Map(ev.SensorReading, AltimeterViewModel);
            });

            await StartSensor(bandClient, bandClient.SensorManager.Distance, ev =>
            {
                Mapper.Map(ev.SensorReading, BandDistanceViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.Gsr, ev =>
            {
                //Mapper.Map(ev.SensorReading, AltimeterViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.Gyroscope, ev =>
            {
                //Mapper.Map(ev.SensorReading, AltimeterViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.Pedometer, ev =>
            {
                Mapper.Map(ev.SensorReading, BandPedometerViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.RRInterval, ev =>
            {
                Mapper.Map(ev.SensorReading, BandRRIntervalViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.SkinTemperature, ev =>
            {
                Mapper.Map(ev.SensorReading, BandSkinTemperatureViewModel);
            });
            await StartSensor(bandClient, bandClient.SensorManager.UV, ev =>
            {
                Mapper.Map(ev.SensorReading, BandUVViewModel);
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
