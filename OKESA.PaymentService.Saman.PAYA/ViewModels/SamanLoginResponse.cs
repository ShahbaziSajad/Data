using System;
using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanLoginResponse : SamanErrorResponse
    {
        [JsonProperty("currentLogin")]
        public DateTime CurrentLogin { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("lastLogin")]
        public DateTime LastLogin { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    //{
        //"currentLogin": "2019-06-22T11:29:43.522Z",
        //"error": "string",
        //"errorCode": "string",
        //"exception": "string",
        //"expiration": "2019-06-22T11:29:43.522Z",
        //"fieldErrors": [
        //{
        //    "code": "string",
        //    "field": "string",
        //    "message": "string",
        //    "rejectedValue": {}
        //}
        //],
        //"gender": "MALE : آقا",
        //"httpStatus": 0,
        //"lastLogin": "2019-06-22T11:29:43.522Z",
        //"message": "string",
        //"name": "string",
        //"path": "string",
        //"timestamp": "2019-06-22T11:29:43.522Z",
        //"token": "string"
    //}
}
