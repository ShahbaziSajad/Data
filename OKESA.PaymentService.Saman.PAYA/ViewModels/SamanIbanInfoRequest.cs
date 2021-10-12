using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanIbanInfoRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("clientIp")]
        public string ClientIp { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    //{
        //"channel": "string",
        //"clientIp": "string",
        //"iban": "string",
        //"token": "string"
    //}
}
