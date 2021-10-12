using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.PaymentService.Api.Version1.ViewModels
{
    public class TransactionReportQueryParams
    {
        public string ReferenceId { get; set; }
        public decimal FromTransactionAmount { get; set; }
        public decimal ToTransactionAmount { get; set; }

        public int Length { get; set; }

        public int Offset { get; set; }

        public string Channel { get; set; }
        public string Cif { get; set; }

        public string Token { get; set; }



    }
}
