using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.PaymentService.Api.Version1.ViewModels
{
    public class ResponseOld
    {
        public string address;
        public object result;
        public string success;
        public string info;
        public string warning;
        public string error;
        public string errorEn;

        public ResponseOld(string address)
        {
            this.address = address;
        }

        public void ErrorSet(Exception ex, string error)
        {
            this.error = error;
            for (int i = 0; i < 5; i++)
                if (ex.InnerException == null)
                {
                    this.errorEn = ex.Message;
                    return;
                }
                else
                    ex = ex.InnerException;
        }
    }
}
