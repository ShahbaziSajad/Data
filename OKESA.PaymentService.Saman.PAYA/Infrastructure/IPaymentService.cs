
using OKESA.PaymentService.Saman.PAYA.Models;

namespace OKESA.PaymentService.Saman.PAYA.Infrastructure
{
    public interface IPaymentService
    {
        SamanLoginResponse Login(SamanLoginRequest request);
        SamanLoginResponse Login(string password);

        /// <summary>
        /// Saman Paya payment request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SamanNormalPaymentResponse NormalPayment(SamanNormalPaymentRequest request);


        /// <summary>
        /// Saman Satna payment request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SamanRtgsPaymentResponse RtgsPayment(SamanRtgsPaymentRequest request);

        /// <summary>
        /// Saman deposit report
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SamanDepositReportResponse DepositReport(SamanDepositReportRequest request);

        SamanNormalTransactionReportResponse NormalTransactionReport(
            SamanNormalTransactionReportRequest request);

        SamanNormalTransactionReportResponse NormalTransactionReport(
            object request);

        /// <summary>
        /// Get iban (sheba no) information
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SamanIbanInfoResponse GetIbanInfo(SamanIbanInfoRequest request);
    }
}
