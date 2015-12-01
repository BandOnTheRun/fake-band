using Microsoft.Band.Notifications;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MSBandAzure.Services.Fakes
{
    public class FakeBandNotificationManager : IBandNotificationManager
    {
        public Task SendMessageAsync(Guid tileId, string title, string body, DateTimeOffset timestamp, MessageFlags flags = MessageFlags.None)
        {
            throw new NotImplementedException();
        }

        public Task SendMessageAsync(Guid tileId, string title, string body, DateTimeOffset timestamp, MessageFlags flags, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task ShowDialogAsync(Guid tileId, string title, string body)
        {
            throw new NotImplementedException();
        }

        public Task ShowDialogAsync(Guid tileId, string title, string body, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task VibrateAsync(VibrationType vibrationType)
        {
            throw new NotImplementedException();
        }

        public Task VibrateAsync(VibrationType vibrationType, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
