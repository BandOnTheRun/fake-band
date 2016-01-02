using System;

namespace MSBandAzure.Services.Fakes
{
    public interface IAppIdProvider
    {
        Guid GetAppId();
    }
}