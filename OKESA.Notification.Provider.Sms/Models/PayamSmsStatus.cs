using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Notification.Provider.Sms.Models
{
    public enum PayamSmsStatus
    {
        Unknown=-1,
        Ok=0,
        AuthError=2,
        ServiceNumberInvalid=3,
        InsufficientCredit=5,
        ToManySms=8,
        AccountDisabled=10,
        IntervalReached=15
    }
}
