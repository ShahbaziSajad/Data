using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Notification.Provider.Sms.Models
{
    public class PayamSmsSettings
    {
        public string Apikey { get; set; }
        public string From { get; set; }
        public string Unicode { get; set; }
        public string SendUrl { get; set; }

    }
}
