using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanLoginRequest
    {
        [JsonProperty("channel")]
        public string Channel { get; set; }
        //public string CorrelationId { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("secretkey")]
        public string SecretKey { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    //{
        //"channel": "string",
        //"correlationId": "string",
        //"password": "string",
        //"secretkey": "string",
        //"username": "string"
    //}
}
