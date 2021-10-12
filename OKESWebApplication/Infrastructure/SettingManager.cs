using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKESWebApplication.Infrastructure
{
    public class SettingManager
    {
        public IConfiguration Configuration { get; private set; }
        public SettingManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    }
}
