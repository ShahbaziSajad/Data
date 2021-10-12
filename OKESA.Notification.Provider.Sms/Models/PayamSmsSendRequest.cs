using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Notification.Provider.Sms.Models
{
    public class PayamSmsSendRequest
    {
        [JsonProperty("apikey")]
        public string ApiKey { get; set; }
        [JsonProperty("from")]
        public string From { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("unicode")]
        public string Unicode { get; set; }
    }
}
