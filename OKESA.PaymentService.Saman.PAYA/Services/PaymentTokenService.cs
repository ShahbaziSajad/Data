using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using OKES.Core.Data.Sql.Abstractions;
using OKESA.PaymentService.Saman.PAYA.Models;
using OKESA.PaymentService.Saman.PAYA.Repositories;

namespace OKESA.PaymentService.Saman.PAYA.Services
{
    public class PaymentTokenService : IPaymentTokenService
    {

        private readonly IPaymentTokenRepository _paymentTokenRepository;

        public PaymentTokenService(ISqlStorage sqlStorage, IMemoryCache cache)
        {
            _paymentTokenRepository = sqlStorage.GetRepository<IPaymentTokenRepository>();
        }

        public string ConnectionString { get; set; }

        public async Task<PaymentToken> GetLastAsync()
        {
            return await _paymentTokenRepository.GetLastAsync(ConnectionString);
        }

        public async Task<int> InsertNewAsync(PaymentToken paymentToken)
        {
            return await _paymentTokenRepository.InsertNewAsync(paymentToken, ConnectionString);
        }
    }
}
