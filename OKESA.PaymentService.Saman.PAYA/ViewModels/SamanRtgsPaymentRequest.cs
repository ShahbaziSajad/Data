using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanRtgsPaymentRequest
    {
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

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

        [JsonProperty("receiverFamily")]
        public string ReceiverFamily { get; set; }

        [JsonProperty("receiverName")]
        public string ReceiverName { get; set; }

        [JsonProperty("receiverTelephoneNumber")]
        public string ReceiverTelephoneNumber { get; set; }

        [JsonProperty("sourceDepositNumber")]
        public string SourceDepositNumber { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("trackerId")]
        public string TrackerId { get; set; }
    }

    //{
        //"amount": 0,
        //"channel": "string",
        //"cif": "string",
        //"clientIp": "string",
        //"description": "string",
        //"destinationIbanNumber": "string",
        //"factorNumber": "string",
        //"receiverFamily": "string",
        //"receiverName": "string",
        //"receiverTelephoneNumber": "string",
        //"sourceDepositNumber": "string",
        //"token": "string",
        //"trackerId": "string"
    //}
}
