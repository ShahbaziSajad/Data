using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.PaymentService.Api.Version1
{
    public static class Constants
    {
        public const string Api = "api";

        public const string ApiVersion = "v1";

        public const string PaymentRoute = "payment";

        public const string PayaRoute = "paya";

        public const string SamanRoute = "saman";
        //api/payment/v1/paya/saman
        public const string SamanPayaRoute = Api + "/" + PaymentRoute + "/" + ApiVersion + "/" + PayaRoute+"/"+ SamanRoute;

        public const string SamanPayaPayRoute = "pay";
        public const string SamanFullPayaPayRoute = SamanPayaRoute+"/pay";

        public const string SamanFullPayaSecurePayRoute = SamanPayaRoute + "/securepay";
        public const string SamanPayaSecurePayRoute = "securepay";


        public const string SamanPayaTransactionReportRoute = "secureTransactionsReport";
        public const string SamanPayaTransactionDestReportRoute = "secureTransactionsDescReport";

    }
}
