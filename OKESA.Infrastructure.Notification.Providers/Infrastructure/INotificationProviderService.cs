using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Infrastructure.Notification.Providers.Infrastructure
{
    public interface INotificationProviderService
    {
        TProvider GetProvider<TProvider>() where TProvider : class;

    }
}
