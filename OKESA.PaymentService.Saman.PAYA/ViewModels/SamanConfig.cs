namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanConfig
    {
        public string ChannelName { get; set; }
        public string SecretKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Cif { get; set; }
        public string TrackerId { get; set; }
        public string ClientIp { get; set; }
        public string TestIbanNumber { get; set; }

        public string AccountNo { get; set; }

        public string BaseURL { get; set; }
        public string LoginURL { get; set; }
        public string TransferNormalURL { get; set; }
        public string TransferRtgsURL { get; set; }
        public string DepositStatementURL { get; set; }
        public string DepositIbanInfoURL { get; set; }
        public string TransferTransactionReportURL { get; set; }

        public string SourceDepositIban { get; set; }

    }
}
