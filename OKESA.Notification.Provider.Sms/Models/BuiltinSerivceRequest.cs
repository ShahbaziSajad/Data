using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Notification.Provider.Sms.Models
{
    public class BuiltinSerivceRequestModel
    {
        public string PhoneNumber { get; set; }
        public string MessageBody { get; set; }
    }

    public class BuiltinSerivceRequest
    {
        public List<BuiltinSerivceRequestModel> Model { get; set; }
    }
}
