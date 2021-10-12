using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanErrorResponse
    {
        [JsonProperty("error")]
        public string Error { get; set; }

        [JsonProperty("exception")]
        public string Exception { get; set; }

        [JsonProperty("fieldErrors")]
        public List<FieldError> FieldErrors { get; set; }

        [JsonProperty("httpStatus")]
        public int HttpStatus { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("timestamp")]
        public DateTime TimeStamp { get; set; }
    }

    public class FieldError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("message")]
        public string Message{ get; set; }

        [JsonProperty("rejectedValue")]
        public dynamic RejectedValue { get; set; }
    }

    //{
        //"error": "string",
        //"exception": "BadRequestException",
        //"fieldErrors": [
        //{
        //    "code": "string",
        //    "field": "string",
        //    "message": "string",
        //    "rejectedValue": {}
        //}
        //],
        //"httpStatus": 0,
        //"message": "string",
        //"path": "string",
        //"timestamp": "2019-06-22T11:31:57.468Z"
    //}
}
