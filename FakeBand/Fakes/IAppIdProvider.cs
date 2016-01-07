using System;

namespace FakeBand.Fakes
{
    public interface IAppIdProvider
    {
        Guid GetAppId();
    }
}