using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OKESA.Infrastructure.SettingsManagers.Infrastructure;
using OKESA.Notification.Provider.Sms.Infrastructure;
using OKESA.Notification.Provider.Sms.Models;
using RestSharp;
using System.Collections.Generic;

namespace OKESA.Notification.Provider.Sms
{
    public class PayamSms: IPayamSmsProvider
    {
        private readonly PayamSmsSettings _options;
        public PayamSms(IOptions<PayamSmsSettings> options)
        {
            _options = options.Value;
        }

        public IRestResponse<PayamSmsSendResponse> Send(PayamSmsSendRequest sendrequest)
        {

            var client = new RestClient(_options.SendUrl);
            client.Timeout = -1;
            client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var builtinParam = new BuiltinSerivceRequest { Model = new List<BuiltinSerivceRequestModel> { new BuiltinSerivceRequestModel { MessageBody = sendrequest.Content, PhoneNumber = sendrequest.To } } };
            request.AddParameter("application/json", JsonConvert.SerializeObject(builtinParam), ParameterType.RequestBody);
            var response = client.Execute<BuiltinServiceResponse>(request);
            var res = new RestResponse<PayamSmsSendResponse>();
            res.Data = new PayamSmsSendResponse { Id = response.Data, Status = PayamSmsStatus.Ok };
            return res;

            //var client = new RestClient(_options.SendUrl);
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Cache-Control", "no-cache");
            //request.AddHeader("Content-Type", "application/json");

            //if (string.IsNullOrEmpty(sendrequest.ApiKey))
            //    sendrequest.ApiKey = _options.Apikey;

            //if (string.IsNullOrEmpty(sendrequest.From))
            //    sendrequest.From = _options.From;

            //if (string.IsNullOrEmpty(sendrequest.Unicode))
            //    sendrequest.Unicode = _options.Unicode;


            //request.AddParameter("undefined", JsonConvert.SerializeObject(sendrequest), ParameterType.RequestBody);
            //var response = client.Execute<PayamSmsSendResponse>(request);
            //response.Data = JsonConvert.DeserializeObject<PayamSmsSendResponse>(response.Content);
            //return response;
        }

    }
}
