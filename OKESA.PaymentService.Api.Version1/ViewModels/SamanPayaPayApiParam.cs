using OKESA.PaymentService.Saman.PAYA.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.PaymentService.Api.Version1.ViewModels
{
    public class SamanPayaPayApiParam: RequestBase
    {
        // شماره سپرده مبدا. طبق نامه شرکت مبدا همیشه باید این سپرده باشد.
        public string SourceDepositNumber { get; set; }

        //مبلغ
        public decimal Amount { get; set; }

        // "یادداشت پایا -اختیاری";
        public string Description { get; set; }

        // عددی دلخواه است و می توان هم وارد نکرد. خود مشتری معنای آنرا می داند
        public string FactorNumber { get; set; }

        // شماره شبا مقصد
        public string IbanNumber { get; set; }

        // نام گیرنده شبا مقصد
        public string OwnerName { get; set; }

        public string PhoneNumber { get; set; }
    }
}
