using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanRtgsPaymentResponse : SamanErrorResponse
    {
        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    //{
        //"balance": 0,
        //"currency": "string",
        //"id": "string"
    //}
}
