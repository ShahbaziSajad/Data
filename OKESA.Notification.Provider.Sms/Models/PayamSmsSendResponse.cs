using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Notification.Provider.Sms.Models
{
    public class PayamSmsSendResponse
    {
        [JsonProperty("status")]
        public PayamSmsStatus Status { get; set; }
        [JsonProperty("id")]
        public object Id { get; set; }
    }
}
