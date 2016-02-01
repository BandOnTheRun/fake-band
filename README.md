# Fake Band
![alt tag](https://raw.github.com/BandOnTheRun/fake-band/master/assets/nobandnoproblem.png)

Library to enable programming against the Microsoft Band SDK without connecting to a physical band
See http://peted.azurewebsites.net/fake-microsoft-band/ for further details and usage

From the package manager console in Visual Studio

**Install-Package FakeBand**

Then you can use the library like this example:

```cs
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

  var wb = meTile.ToWriteableBitmap();
  MeTileImage.Source = wb;
```
Where MeTileImage is a XAML image control

Or this example to subscribe for sensor data:

```cs
var uc = bandClient.SensorManager.Accelerometer.GetCurrentUserConsent();
bool isConsented = false;

if (uc == UserConsent.NotSpecified)
{
    isConsented = await bandClient.SensorManager.Accelerometer.RequestUserConsentAsync();
}

if (isConsented || uc == UserConsent.Granted)
{
    bandClient.SensorManager.Accelerometer.ReadingChanged += async (obj, ev) =>
    {
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            // Update User Interface...
        });
    };

    await bandClient.SensorManager.Accelerometer.StartReadingsAsync();
}
```
