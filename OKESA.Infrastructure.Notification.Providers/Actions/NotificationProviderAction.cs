using Microsoft.Extensions.DependencyInjection;
using OKES.Core.Infrastructure;
using OKES.Core.Infrastructure.Actions;
using OKESA.Infrastructure.Notification.Providers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OKESA.Infrastructure.Notification.Providers.Actions
{
    public class NotificationProviderAction : IConfigureServicesAction
    {
        public int Priority => 10001;

        public void Execute(IServiceCollection serviceCollection, IServiceProvider serviceProvider)
        {
            var types = ExtensionManager.GetImplementations<INotificationProviderService>()?.Where(t => !t.GetTypeInfo().IsAbstract);

            if (types == null)
            {
                return;
            }

            foreach (var type in types)
            {
                serviceCollection.AddScoped(typeof(INotificationProviderService), type);
            }

        }
    }
}
