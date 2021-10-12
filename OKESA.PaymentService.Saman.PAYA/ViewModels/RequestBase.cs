using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.PaymentService.Saman.PAYA.ViewModels
{
    public abstract class RequestBase
    {
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("channel")]
        public string Channel { get; set; }

        [JsonProperty("cif")]
        public string Cif { get; set; }

    }
}
