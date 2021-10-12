using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using OKES.Core.Data.Dapper;
using OKES.Core.Data.Sql.Abstractions;
using OKES.Core.Security.ActionFilters;
using OKESA.Infrastructure.Notification.Providers.Infrastructure;
using OKESA.Notification.Provider.Sms;
using OKESA.Notification.Provider.Sms.Infrastructure;
using OKESA.Notification.Provider.Sms.Models;
using OKESA.PaymentService.Api.Version1.ViewModels;
using OKESA.PaymentService.Saman.PAYA.Infrastructure;
using OKESA.PaymentService.Saman.PAYA.Models;
using OKESA.PaymentService.Saman.PAYA.Services;
using OKESA.PaymentService.Saman.PAYA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKESA.PaymentService.Api.Version1.Controllers
{

    [Route(Constants.SamanPayaRoute)]
    public class SamanPayaController : Controller
    {
        private readonly IPaymentTokenService _paymentTokenService;
        private IOptions<DapperStorageContextOptions> _options;
        private readonly IConfiguration _configuration;
        private readonly IPayamSmsProvider _payamSmsProvider;
        private readonly SamanConfig _samanConfigOptions;
        private readonly IPaymentService _paymentService;

        public SamanPayaController(ISqlStorageService sqlStorage,
            IOptions<DapperStorageContextOptions> options,
            INotificationProviderService notificationProviderService,
            IConfiguration configuration,
            IOptions<SamanConfig> samanConfigOptions,
            IPaymentService paymentService)
        {
            _options = options;
            _paymentService = paymentService;
            _paymentTokenService = sqlStorage.GetRepositoryService<IPaymentTokenService>();
            _paymentTokenService.ConnectionString = _options.Value.DefaultConnectionString;
            _payamSmsProvider = notificationProviderService.GetProvider<PayamSms>();
            _configuration = configuration;
            _samanConfigOptions = samanConfigOptions.Value;

        }

        private async Task<string> GetTokenAsync(ResponseOld response)
        {
            //var lastToken = await _paymentTokenService.GetLastAsync();
            string token;
            //if ((lastToken.CreateDate.AddMinutes(5) - DateTime.Now).TotalSeconds > 0)
            //{
            //    token = lastToken.Token;
            //}
            
                var login = _paymentService.Login(new SamanLoginRequest
                {
                    Channel = _samanConfigOptions.ChannelName,
                    Password = _samanConfigOptions.Password,
                    SecretKey = _samanConfigOptions.SecretKey,
                    Username = _samanConfigOptions.Username
                });
                if (login == null || string.IsNullOrEmpty(login.Token))
                {
                    response.error = "ورود به بانک سامان ناموفق بود";
                    response.errorEn = "Saman login error";
                    return "";
                }
                token = login.Token;
                var resIns = await _paymentTokenService.InsertNewAsync(new PaymentToken { Token = token });
            
            return token;
        }

        [HttpPost]
        [Authorize]
        [Loggable]
        [Route(Constants.SamanPayaSecurePayRoute)]
        public async Task<ResponseOld> SecurePayAsync([FromBody]SamanPayaPayApiParam payParam)
        {
            var response = new ResponseOld("PayaPayApi.Pay");
            if (payParam == null) return response;
            try
            {
                string token = await GetTokenAsync(response);
                if (string.IsNullOrEmpty(token))
                    return response;

                var resPay = _paymentService.NormalPayment(new SamanNormalPaymentRequest
                {
                    Amount = payParam.Amount,
                    Channel = _samanConfigOptions.ChannelName,
                    Cif = _samanConfigOptions.Cif,
                    Description = payParam.Description + "-" + HttpContext.User.Identity.Name,
                    Token = token,
                    //TransferDescription = "test saman transfer",
                    //FactorNumber = "21254684",
                    SourceDepositNumber = _samanConfigOptions.AccountNo,
                    IbanNumber = payParam.IbanNumber,
                    //ClientIp = SamanConfig.ClientIp,
                    OwnerName = payParam.OwnerName,
                    TrackerId = Guid.NewGuid().ToString()
                });
                response.result = resPay;
                if (!string.IsNullOrEmpty(resPay.Error))
                {
                    response.error = resPay.Message;
                    response.errorEn = resPay.Error;
                    return response;
                }
                if (resPay.TransactionStatus == DestinationTransactionStatus.ACCEPTED)
                {
                    response.success = "true";
                    if (!string.IsNullOrEmpty(payParam.PhoneNumber))
                    {
                        _payamSmsProvider.Send(new PayamSmsSendRequest
                        {
                            Content = string.Format(_configuration["Messages:DriverPayment:Success"], payParam.FactorNumber, payParam.Amount),
                            To = payParam.PhoneNumber
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                response.ErrorSet(ex, "عملیات پرداخت پایا با خطا مواجه شد - ShabaNo:" + payParam.IbanNumber?.ToString()
                    + " | HazinePardakhti:" + payParam.Amount.ToString());
                return response;
            }
            return response;
        }

        [HttpPost]
        [Authorize]
        [Route(Constants.SamanPayaTransactionReportRoute)]
        public async Task<ResponseOld> SecureTransactionsReportAsync([FromBody]SamanNormalTransactionReportRequest reportParam)
        {
            InitReportValues(reportParam);
            return await SendSecureTransactionsReportAsync(reportParam);
        }

        //[HttpPost]
        //[Authorize]
        //[Route(Constants.SamanPayaTransactionDestReportRoute)]
        //public async Task<ResponseOld> SecureTransactionsReportAsync([FromBody]SamanDescTransactionReportRequest reportParam)
        //{
        //    InitReportValues(reportParam);
        //    return await SendSecureTransactionsReportAsync(reportParam);
        //}

        public void InitReportValues(SamanNormalTransactionReportRequest reportParam)
        {

            if (reportParam.Length == 0) reportParam.Length = 10000;
            if (reportParam.FromTransactionAmount == 0) reportParam.FromTransactionAmount = 1;
            if (reportParam.ToTransactionAmount == 0) reportParam.ToTransactionAmount = 1000000000;
            if (reportParam.FromIssueDate==default) reportParam.FromIssueDate = DateTime.Now.AddDays(-7);
            if (reportParam.ToIssueDate== default) reportParam.ToIssueDate = DateTime.Now.AddDays(1);
            reportParam.SourceDepositIban = _samanConfigOptions.SourceDepositIban;
            reportParam.Channel = _samanConfigOptions.ChannelName;
            reportParam.Cif = _samanConfigOptions.Cif;
            reportParam.Source = _samanConfigOptions.AccountNo;
            //reportParam.Username = _samanConfigOptions.Username;
            //reportParam.Password = _samanConfigOptions.Password;
            reportParam.ClientIp = _samanConfigOptions.ClientIp;
        }

        public async Task<ResponseOld> SendSecureTransactionsReportAsync(SamanNormalTransactionReportRequest reportParam)
        {
            var response = new ResponseOld("PayaPayApi.Pay");
            if (reportParam == null) return response;
            try
            {
                string token = await GetTokenAsync(response);
                if (string.IsNullOrEmpty(token))
                    return response;

                //if (reportParam.Length == 0) reportParam.Length = 10000;
                //if (reportParam.FromTransactionAmount == 0) reportParam.FromTransactionAmount = 1;
                //if (reportParam.ToTransactionAmount == 0) reportParam.ToTransactionAmount = 1000000000;
                //var report = _paymentService.NormalTransactionReport(new SamanReferTransactionReportRequest
                //{
                //    Channel = _samanConfigOptions.ChannelName,
                //    Cif = _samanConfigOptions.Cif,
                //    ReferenceId = reportParam.ReferenceId,
                //    Description = reportParam.Description,
                //    Token = token,
                //    FromTransactionAmount = reportParam.FromTransactionAmount,
                //    ToTransactionAmount = reportParam.ToTransactionAmount,
                //    Offset = reportParam.Offset,
                //    Length = reportParam.Length

                //});
                reportParam.Token = token;
                var report = _paymentService.NormalTransactionReport(reportParam);
                var first = report?.Transactions?.FirstOrDefault();
                response.result = first;
                if (!string.IsNullOrEmpty(report.Error))
                {
                    response.error = report.Message;
                    response.errorEn = report.Error;
                    return response;
                }
                else
                {
                    response.success = "true";
                }
            }
            catch (Exception ex)
            {
                response.ErrorSet(ex, "error");
                return response;
            }
            return response;

        }


    }
}
