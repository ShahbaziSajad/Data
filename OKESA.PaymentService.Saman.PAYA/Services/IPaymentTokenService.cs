using OKES.Core.Data.Sql.Abstractions;
using OKESA.PaymentService.Saman.PAYA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OKESA.PaymentService.Saman.PAYA.Services
{
    public interface IPaymentTokenService : ISqlRepositoryService
    {
        string ConnectionString { get; set; }
        Task<PaymentToken> GetLastAsync();
        Task<int> InsertNewAsync(PaymentToken paymentToken);

    }
}
