using OKES.Core.Infrastructure;
using OKESA.Infrastructure.Notification.Providers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Infrastructure.Notification.Providers
{
    public class NotificationProviderService : INotificationProviderService
    {
        private IServiceProvider _serviceProvider;
        public NotificationProviderService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public TProvider GetProvider<TProvider>() where TProvider : class
        {
            bool assignable = typeof(INotificationProvider).IsAssignableFrom(typeof(TProvider));
            if (!assignable)
                throw new ArrayTypeMismatchException("Type must implemented INotificationProvider");
            TProvider repository = ExtensionManager.GetInstance<TProvider>(_serviceProvider);

            return repository;
        }
    }
}
