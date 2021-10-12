using OKES.Core.Data.Sql.Abstractions;
using OKESA.PaymentService.Saman.PAYA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OKESA.PaymentService.Saman.PAYA.Repositories
{
    public interface IPaymentTokenRepository : ISqlRepository
    {
        Task<PaymentToken> GetLastAsync(string cn);
        Task<int> InsertNewAsync(PaymentToken paymentToken, string cn);


    }
}
