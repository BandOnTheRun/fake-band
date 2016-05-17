using AutoMapper;
using FakeBand.Fakes;
using FakeBandClientTestApp.Controls;
using FakeBandClientTestApp.ViewModels;
using Microsoft.Band;
using Microsoft.Band.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FakeBandClientTestApp
{
    public class Transport : ITransport
    {
        DispatcherTimer _timer = new DispatcherTimer();
        public Transport()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(100);
            _timer.Tick += OnTick;
        }

        DateTimeOffset _startTime;

        private void OnTick(object sender, object e)
        {
            var dt = sender as DispatcherTimer;
            DateTimeOffset time = DateTimeOffset.Now;
            TimeSpan span = time - _startTime;
            OnTicked(span);
        }

        PlayState _currentState;

        public event TransportTickHandler Tick;

        protected void OnTicked(TimeSpan span)
        {
            var ev = Tick;
            if (ev == null)
                return;
            ev(span);
        }

        public PlayState CurrentState
        {
            get
            {
                return _currentState;
            }

            set
            {
                if (value == _currentState)
                    return;
                _currentState = value;
            }
        }

        public void Pause()
        {
            _currentState = PlayState.Paused;
        }

        public void Play()
        {
            _currentState = PlayState.Playing;
        }

        public void Record()
        {
            _currentState = PlayState.Recording;
            _startTime = DateTime.Now;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public long CurrentTime { get; set; }
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static readonly public string LabelPostfix = ": ";

        public Transport Transport { get; set; }

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

            Transport = new Transport();

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
