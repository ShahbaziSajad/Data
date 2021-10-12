using System;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OKESA.PaymentService.Saman.PAYA.Infrastructure;
using OKESA.PaymentService.Saman.PAYA.Models;
using RestSharp;

namespace OKESA.PaymentService.Saman.PAYA
{
    public class PaymentService : IPaymentService
    {
        private readonly SamanConfig _samanConfigOptions;

        public PaymentService(IOptions<SamanConfig> samanConfigOptions)
        {
            _samanConfigOptions = samanConfigOptions.Value;
        }
        private RestRequest FormatRequest(RestRequest req) {

            req.AddHeader("cache-control", "no-cache");
            req.AddHeader("Connection", "keep-alive");
            req.AddHeader("content-length", "127");
            req.AddHeader("accept-encoding", "gzip, deflate");
            req.AddHeader("Host", _samanConfigOptions.BaseURL);
            req.AddHeader("Content-Type", "application/json");
            //req.AddHeader("X-Forwarded-For", "172.31.64.39");
            return req;
        }

        public SamanLoginResponse Login(SamanLoginRequest request)
        {
            var client = new RestClient(_samanConfigOptions.LoginURL);
            var res = new RestRequest(Method.POST);
            res = FormatRequest(res);
            res.AddParameter("undefined", JsonConvert.SerializeObject(request),
                ParameterType.RequestBody);

            var response = client.Execute<SamanLoginResponse>(res);

            return response.Data;
        }

        public SamanLoginResponse Login(string password)
        {
            var loginRequest = new SamanLoginRequest
            {
                Channel = _samanConfigOptions.ChannelName,
                Password = password,
                Username = _samanConfigOptions.Username,
                SecretKey = _samanConfigOptions.SecretKey
            };

            return Login(loginRequest);
        }

        public SamanNormalPaymentResponse NormalPayment(SamanNormalPaymentRequest request)
        {
            var client = new RestClient(_samanConfigOptions.TransferNormalURL); ;
            var res = new RestRequest(Method.POST);
            res = FormatRequest(res);
            res.AddParameter("undefined", JsonConvert.SerializeObject(request),
                ParameterType.RequestBody);

            var response = client.Execute<SamanNormalPaymentResponse>(res);

            return response.Data;
        }

        public SamanRtgsPaymentResponse RtgsPayment(SamanRtgsPaymentRequest request)
        {
            var client = new RestClient(_samanConfigOptions.TransferRtgsURL);
            var res = new RestRequest(Method.POST);
            res = FormatRequest(res);
            res.AddParameter("undefined", JsonConvert.SerializeObject(request),
                ParameterType.RequestBody);

            var response = client.Execute<SamanRtgsPaymentResponse>(res);

            return response.Data;
        }

        public SamanDepositReportResponse DepositReport(SamanDepositReportRequest request)
        {
            var client = new RestClient(_samanConfigOptions.DepositStatementURL);
            var res = new RestRequest(Method.POST);
            res = FormatRequest(res);
            res.AddParameter("undefined", JsonConvert.SerializeObject(request),
                ParameterType.RequestBody);

            var response = client.Execute<SamanDepositReportResponse>(res);

            return response.Data;
        }

        public SamanIbanInfoResponse GetIbanInfo(SamanIbanInfoRequest request)
        {
            var client = new RestClient(_samanConfigOptions.DepositIbanInfoURL);
            var res = new RestRequest(Method.POST);
            res = FormatRequest(res);
            res.AddParameter("undefined", JsonConvert.SerializeObject(request),
                ParameterType.RequestBody);

            var response = client.Execute<SamanIbanInfoResponse>(res);

            return response.Data;
        }

        public SamanNormalTransactionReportResponse NormalTransactionReport(
            SamanNormalTransactionReportRequest request)
        {
            var client = new RestClient(_samanConfigOptions.TransferTransactionReportURL);
            var res = new RestRequest(Method.POST);
            res = FormatRequest(res);
            string jsonMsDate = JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd'T'HH:mm:ss"
            });
            res.AddParameter("undefined", jsonMsDate,
                ParameterType.RequestBody);

            var response = client.Execute<SamanNormalTransactionReportResponse>(res);

            return response.Data;
        }

        public SamanNormalTransactionReportResponse NormalTransactionReport(
            object request)
        {
            var client = new RestClient(_samanConfigOptions.TransferTransactionReportURL);
            var res = new RestRequest(Method.POST);
            res = FormatRequest(res);
            res.AddParameter("undefined", JsonConvert.SerializeObject(request),
                ParameterType.RequestBody);

            var response = client.Execute<SamanNormalTransactionReportResponse>(res);

            return response.Data;
        }

    }
}
