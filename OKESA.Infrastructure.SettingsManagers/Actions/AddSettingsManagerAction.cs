using Microsoft.Extensions.DependencyInjection;
using OKES.Core.Infrastructure;
using OKES.Core.Infrastructure.Actions;
using OKESA.Infrastructure.SettingsManagers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OKESA.Infrastructure.SettingsManagers.Actions
{
    public class AddSettingsManagerAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection serviceCollection, IServiceProvider serviceProvider)
        {
            var types = ExtensionManager.GetImplementations<ISettingsManager>()?.Where(t => !t.GetTypeInfo().IsAbstract);

            if (types == null)
            {
                return;
            }
            
            foreach (var type in types)
            {
                serviceCollection.AddScoped(typeof(ISettingsManager), type);
            }
            serviceCollection.AddScoped(typeof(ISmsSettingsManager), typeof(SmsSettingsManager));

        }
    }
}
