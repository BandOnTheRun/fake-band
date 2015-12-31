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
                        tcs.SetResult(5858);
                };
                await sensor.StartReadingsAsync();
            }

            var timeoutTask = Task.Delay(5000);
            await tcs.Task;

            var completedTaskId = Task.WaitAny(timeoutTask, tcs.Task);

            // assert on the index of the completed task..
            Assert.Equal(1, completedTaskId);

            await sensor.StopReadingsAsync();

            return tcs.Task.Result;
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectHeartRateAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.HeartRate, 5000, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectSkinTempAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.SkinTemperature, 5000, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectUVAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.UV, 5000, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectCaloriesAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.Calories, 5000, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectAltimeterAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.Altimeter, 5000, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectAmbientLightAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.AmbientLight, 5000, 5858);
            
            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectRRIntervalAndReceiveOneValue()
        {
            var bandClient = await TestUtils.GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.RRInterval, 5000, 5858);

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