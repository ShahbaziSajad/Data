using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanIbanInfoResponse
    {
        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("accountStatus")]
        public string AccountStatus { get; set; }

        [JsonProperty("acountComment")]
        public string AcountComment { get; set; }

        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }
    }

    //{
        //"accountNumber": "string",
        //"accountStatus": "ACTIVE : حساب فعال است",
        //"acountComment": "string",
        //"bank": "string",
        //"firstName": "string",
        //"lastName": "string"
    //}
}
