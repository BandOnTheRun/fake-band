using FakeBand.Tests.Utils;
using Microsoft.Band;
using Microsoft.Band.Sensors;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml.Media.Imaging;
using Xunit;

namespace FakeBand.Tests
{
    public class FakeBandClientTests
    {
        public async Task<int> SetupSensor<T>(IBandSensor<T> sensor, int timeout, int value) where T : IBandSensorReading
        {
            var bandClient = await TestUtils.GetBandClientAsync();

            var uc = sensor.GetCurrentUserConsent();
            bool isConsented = false;
            if (uc == UserConsent.NotSpecified)
            {
                isConsented = await sensor.RequestUserConsentAsync();
            }

            var tcs = new TaskCompletionSource<int>();
            if (isConsented || uc == UserConsent.Granted)
            {
                sensor.ReadingChanged += (obj, ev) =>
                {
                    // Set arbitrary result value
                    if (tcs.Task.Status != TaskStatus.RanToCompletion && tcs.Task.Status != TaskStatus.Faulted)
                    {
                        tcs.SetResult(5858);
                    }
                };
                await sensor.StartReadingsAsync();
            }

            try
            {
                await tcs.Task.TimeoutAfter(timeout);
            }
            finally
            {
                await sensor.StopReadingsAsync();
            }

            return tcs.Task.Result;
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectHeartRateAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.HeartRate, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectSkinTempAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.SkinTemperature, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectUVAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.UV, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectCaloriesAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.Calories, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectAltimeterAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.Altimeter, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectAmbientLightAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.AmbientLight, 500, 5858);
            
            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectRRIntervalAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.RRInterval, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectPedometerAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.Pedometer, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectContactAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.Contact, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectDistanceAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.Distance, 500, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_SetMeTile_SetValidImage()
        {
            var bandClient = await TestUtils.GetBandClientAsync();

            // TODO: load image from base64 encoded byte array and assert expected content
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Images/BandImage.png"));
            var str = await file.OpenReadAsync();
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var wb = new WriteableBitmap(1, 1);

                await wb.SetSourceAsync(str);

                var bandImg = wb.ToBandImage();
                await bandClient.PersonalizationManager.SetMeTileImageAsync(bandImg);
                var bandImage = await bandClient.PersonalizationManager.GetMeTileImageAsync();

                var wbmp = bandImage.ToWriteableBitmap();
                Assert.True(wbmp.PixelHeight > 0);
                Assert.True(wbmp.PixelWidth > 0);
                Assert.True(wbmp.PixelBuffer.Length == wbmp.PixelHeight * wbmp.PixelWidth * 4);
            });
        }

        [Fact]
        public async Task FakeBandClient_GetMeTile_GetsValidImage()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var bandImage = await bandClient.PersonalizationManager.GetMeTileImageAsync();

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var wb = bandImage.ToWriteableBitmap();
                Assert.True(wb.PixelHeight > 0);
                Assert.True(wb.PixelWidth > 0);
                Assert.True(wb.PixelBuffer.Length == wb.PixelHeight * wb.PixelWidth * 4);
            });
        }
    }
}