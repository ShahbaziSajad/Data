using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanNormalPaymentRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("cif")]
        public string Cif { get; set; }

        //[JsonProperty("clientIp")]
        //public string ClientIp { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        //[JsonProperty("factorNumber")]
        //public string FactorNumber { get; set; }

        [JsonProperty("ibanNumber")]
        public string IbanNumber { get; set; }

        [JsonProperty("ownerName")]
        public string OwnerName { get; set; }

        [JsonProperty("sourceDepositNumber")]
        public string SourceDepositNumber { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("trackerId")]
        public string TrackerId { get; set; }

        //[JsonProperty("transferDescription")]
        //public string TransferDescription { get; set; }
    }

    //{
        //"amount": 0,
        //"channel": "string",
        //"cif": "string",
        //"clientIp": "string",
        //"description": "string",
        //"factorNumber": "string",
        //"ibanNumber": "string",
        //"ownerName": "string",
        //"sourceDepositNumber": "string",
        //"token": "string",
        //"trackerId": "string",
        //"transferDescription": "string"
    //}
}
