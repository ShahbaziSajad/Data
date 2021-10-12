using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanNormalPaymentResponse : SamanErrorResponse
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("factorNumber")]
        public string FactorNumber { get; set; }

        [JsonProperty("ibanNumber")]
        public string IbanNumber { get; set; }

        [JsonProperty("ownerName")]
        public string OwnerName { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("sourceIbanNumber")]
        public string SourceIbanNumber { get; set; }

        [JsonProperty("transactionStatus")]
        public DestinationTransactionStatus TransactionStatus { get; set; }

        [JsonProperty("transferDescription")]
        public string TransferDescription { get; set; }

        [JsonProperty("transferStatus")]
        public string TransferStatus { get; set; }
    }

    //{
        //"amount": 0,
        //"currency": "string",
        //"description": "string",
        //"factorNumber": "string",
        //"ibanNumber": "string",
        //"ownerName": "string",
        //"referenceId": "string",
        //"sourceIbanNumber": "string",
        //"transactionStatus": "ACCEPTED : از طرف بانک پذیرفته شده",
        //"transferDescription": "string",
        //"transferStatus": "BRANCH_REJECT : برگشت داده شده توسط شعبه"
    //}
}
