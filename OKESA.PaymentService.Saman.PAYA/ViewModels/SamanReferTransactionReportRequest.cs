using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using OKESA.PaymentService.Saman.PAYA.ViewModels;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanReferTransactionReportRequest : TransactionReportRequestBase
    {
        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class SamanDescTransactionReportRequest : TransactionReportRequestBase
    {
        [JsonProperty("description")]
        public string Description { get; set; }

    }
}
