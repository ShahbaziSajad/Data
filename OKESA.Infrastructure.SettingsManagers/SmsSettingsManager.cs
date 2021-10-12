using Microsoft.Extensions.Configuration;
using OKESA.Infrastructure.SettingsManagers.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Infrastructure.SettingsManagers
{
    public class SmsSettingsManager: ISmsSettingsManager
    {
        public const string RootName = "Sms";
        public const string PayamSmsName = "PayamSms";
        public const string PayamSmsApiKeyName = "apikey";
        public const string PayamSmsFromName = "from";
        public const string PayamSmsUnicodeName = "unicode";
        public const string SendUrlName = "sendurl";

        public KeyValuePair<string, string> PayamSmsApiKey { get; private set; }
        public KeyValuePair<string, string> PayamSmsFrom { get; private set; }
        public KeyValuePair<string, string> PayamSmsUnicode { get; private set; }
        public KeyValuePair<string, string> PayamSmsSendUrl { get; private set; }
        public KeyValuePair<string, List<KeyValuePair<string, string>>> PayamSms { get; private set; }



        public IConfiguration Configuration { get; private set; }
        public SmsSettingsManager(IConfiguration configuration)
        {
            Configuration = configuration;
            PayamSmsApiKey = new KeyValuePair<string, string>(PayamSmsApiKeyName, configuration[$"{RootName}:{PayamSmsName}:{PayamSmsApiKeyName}"]);
            PayamSmsFrom = new KeyValuePair<string, string>(PayamSmsFromName, configuration[$"{RootName}:{PayamSmsName}:{PayamSmsFromName}"]);
            PayamSmsUnicode = new KeyValuePair<string, string>(PayamSmsUnicodeName, configuration[$"{RootName}:{PayamSmsName}:{PayamSmsUnicodeName}"]);
            PayamSmsSendUrl = new KeyValuePair<string, string>(SendUrlName, configuration[$"{RootName}:{PayamSmsName}:{SendUrlName}"]);
        }
    }
}
