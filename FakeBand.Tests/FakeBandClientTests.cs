using FakeBand.Fakes;
using Microsoft.Band;
using Microsoft.Band.Sensors;
using MSBandAzure.Services.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<IBandClient> GetBandClientAsync()
        {
            FakeBandClientManager.Configure(new FakeBandClientManagerOptions
            {
                Bands = new List<IBandInfo>
                {
                    new FakeBandInfo(BandConnectionType.Bluetooth, "Fake Band 1"),
                }
            });

            var bands = await FakeBandClientManager.Instance.GetBandsAsync();
            var bandInfo = bands.First();
            var bandClient = await FakeBandClientManager.Instance.ConnectAsync(bandInfo);

            return bandClient;
        }

        public async Task<int> SetupSensor<T>(IBandSensor<T> sensor, int timeout, int value) where T : IBandSensorReading
        {
            var bandClient = await GetBandClientAsync();

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
            var bandClient = await GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.HeartRate, 5000, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectSkinTempAndReceiveOneValue()
        {
            var bandClient = await GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.SkinTemperature, 5000, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_TestValueReceived_ConnectUVAndReceiveOneValue()
        {
            var bandClient = await GetBandClientAsync();
            var res = await SetupSensor(bandClient.SensorManager.UV, 5000, 5858);

            Assert.Equal(5858, res);
        }

        [Fact]
        public async Task FakeBandClient_SetMeTile_SetValidImage()
        {
            var bandClient = await GetBandClientAsync();

            // TODO: load image from base64 encoded byte array and assert expected content
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            var imgFolder = await storageFolder.GetFolderAsync("Images");
            var file = await imgFolder.GetFileAsync("BandImage.png");
            var str = await file.OpenReadAsync();
            var wb = new WriteableBitmap(1, 1);

            await wb.SetSourceAsync(str);

            var bandImg = wb.ToBandImage();
            await bandClient.PersonalizationManager.SetMeTileImageAsync(bandImg);
            var bandImage = await bandClient.PersonalizationManager.GetMeTileImageAsync();
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var wbmp = bandImage.ToWriteableBitmap();
                Assert.True(wbmp.PixelHeight > 0);
                Assert.True(wbmp.PixelWidth > 0);
                Assert.True(wbmp.PixelBuffer.Length == wbmp.PixelHeight * wbmp.PixelWidth * 2);
            });
        }
            [Fact]
        public async Task FakeBandClient_GetMeTile_GetsValidImage()
        {
            var bandClient = await GetBandClientAsync();
            var bandImage = await bandClient.PersonalizationManager.GetMeTileImageAsync();

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var wb = bandImage.ToWriteableBitmap();
                Assert.True(wb.PixelHeight > 0);
                Assert.True(wb.PixelWidth > 0);
                Assert.True(wb.PixelBuffer.Length == wb.PixelHeight * wb.PixelWidth * 2);
            });
        }
    }
}