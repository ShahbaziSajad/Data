using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Notification.Provider.Sms.Models
{
   
    public class BuiltinServiceResponseResult
    {
        public object clientId { get; set; }
        public int msgId { get; set; }
    }

    public class BuiltinServiceResponse
    {
        public List<BuiltinServiceResponseResult> results { get; set; }
    }
}
