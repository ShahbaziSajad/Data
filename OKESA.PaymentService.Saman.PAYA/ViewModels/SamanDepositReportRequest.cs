using System;
using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanDepositReportRequest
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("cif")]
        public string Cif { get; set; }

        [JsonProperty("clientIp")]
        public string ClientIp { get; set; }

        [JsonProperty("depositNumber")]
        public string DepositNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("englishDescription")]
        public string EnglishDescription { get; set; }

        [JsonProperty("fromDate")]
        public DateTime FromDate { get; set; }

        [JsonProperty("length")]
        public int Length { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }

        [JsonProperty("toDate")]
        public DateTime ToDate { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }

    //{
        //"action": "CREDIT : واریز",
        //"channel": "string",
        //"cif": "string",
        //"clientIp": "string",
        //"depositNumber": "string",
        //"description": "string",
        //"englishDescription": "PER : فارسی",
        //"fromDate": "2019-06-22T12:07:51.643Z",
        //"length": 0,
        //"offset": 0,
        //"order": "DESC : نزولی",
        //"toDate": "2019-06-22T12:07:51.643Z",
        //"token": "string"
    //}
}
