using OKES.Core.Data.Dapper;
using OKESA.PaymentService.Saman.PAYA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKESA.PaymentService.Saman.PAYA.Repositories
{
    public class PaymentTokenRepository : DapperRepositoryBase, IPaymentTokenRepository
    {
        public PaymentTokenRepository():base(" ")
        {

        }

        public async Task<PaymentToken> GetLastAsync(string cn)
        {
            ConnectionString = cn;
            var res = await SelectAsync<PaymentToken>(@"SELECT TOP (1) Id,Token,CreateDate FROM dbo.PaymentTokens ORDER BY CreateDate DESC", null);
            return res.FirstOrDefault();
        }

        public async Task<int> InsertNewAsync(PaymentToken paymentToken, string cn)
        {
            ConnectionString = cn;
            var sql = @"INSERT INTO dbo.PaymentTokens(Token,CreateDate) VALUES (@Token, GETDATE());";
            var res=await ExecuteAsync(sql, new { Token = paymentToken.Token });
            return res;
        }
    }
}
