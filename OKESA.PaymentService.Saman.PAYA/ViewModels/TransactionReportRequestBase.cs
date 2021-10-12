using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.PaymentService.Saman.PAYA.ViewModels
{
    public class TransactionReportRequestBase: RequestBase
    {
        [JsonProperty("fromTransactionAmount")]
        public decimal FromTransactionAmount { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("toTransactionAmount")]
        public decimal ToTransactionAmount { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("sourceDepositIban")]
        public string SourceDepositIban { get; set; }
        [JsonProperty("fromIssueDate")]
        public DateTime FromIssueDate { get; set; }

        [JsonProperty("toIssueDate")]
        public DateTime ToIssueDate { get; set; }

        [JsonProperty("clientIp")]
        public string ClientIp { get; set; }
    }
}
