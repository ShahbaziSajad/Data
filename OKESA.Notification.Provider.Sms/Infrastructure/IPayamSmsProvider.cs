using OKESA.Notification.Provider.Sms.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.Notification.Provider.Sms.Infrastructure
{
    public interface IPayamSmsProvider: ISmsProvider
    {
        IRestResponse<PayamSmsSendResponse> Send(PayamSmsSendRequest sendrequest);
    }
}
