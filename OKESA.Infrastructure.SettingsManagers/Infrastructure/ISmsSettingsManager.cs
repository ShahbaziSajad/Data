using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Infrastructure.SettingsManagers.Infrastructure
{
    public interface ISmsSettingsManager : ISettingsManager
    {
        KeyValuePair<string, string> PayamSmsApiKey { get; }
        KeyValuePair<string, string> PayamSmsFrom { get;  }
        KeyValuePair<string, string> PayamSmsUnicode { get; }
        KeyValuePair<string, string> PayamSmsSendUrl { get; }
    }
}
