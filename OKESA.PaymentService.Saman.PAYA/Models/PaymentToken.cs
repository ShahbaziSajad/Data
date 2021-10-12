using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class PaymentToken
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
