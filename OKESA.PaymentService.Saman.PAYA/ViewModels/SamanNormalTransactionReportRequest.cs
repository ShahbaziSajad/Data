using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanNormalTransactionReportRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("cif")]
        public string Cif { get; set; }

        [JsonProperty("clientIp")]
        public string ClientIp { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("destinationIbanNumber")]
        public string DestinationIbanNumber { get; set; }

        [JsonProperty("factorNumber")]
        public string FactorNumber { get; set; }

        [JsonProperty("fromIssueDate")]
        public DateTime FromIssueDate { get; set; }

        [JsonProperty("fromRegisterDate")]
        public DateTime? FromRegisterDate { get; set; }

        [JsonProperty("fromTransactionAmount")]
        public decimal FromTransactionAmount { get; set; }

        [JsonProperty("ibanOwnerName")]
        public string IbanOwnerName { get; set; }

        [JsonProperty("includeTransactionStatus")]
        public List<string> IncludeTransactionStatus { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("sourceDepositIban")]
        public string SourceDepositIban { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("toIssueDate")]
        public DateTime ToIssueDate { get; set; }

        [JsonProperty("toRegisterDate")]
        public DateTime? ToRegisterDate { get; set; }

        [JsonProperty("toTransactionAmount")]
        public decimal ToTransactionAmount { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("transferDescription")]
        public string TransferDescription { get; set; }
    }

    //{
    //"channel": "string",
    //"cif": "string",
    //"clientIp": "string",
    //"description": "string",
    //"destinationIbanNumber": "string",
    //"factorNumber": "string",
    //"fromIssueDate": "2019-06-23T03:42:03.028Z",
    //"fromRegisterDate": "2019-06-23T03:42:03.028Z",
    //"fromTransactionAmount": 0,
    //"ibanOwnerName": "string",
    //"includeTransactionStatus": [
    //"لغو شده"
    //],
    //"length": 0,
    //"offset": 0,
    //"referenceId": "string",
    //"sourceDepositIban": "string",
    //"toIssueDate": "2019-06-23T03:42:03.028Z",
    //"toRegisterDate": "2019-06-23T03:42:03.028Z",
    //"toTransactionAmount": 0,
    //"token": "string",
    //"transactionId": "string",
    //"transferDescription": "string"
    //}
}
