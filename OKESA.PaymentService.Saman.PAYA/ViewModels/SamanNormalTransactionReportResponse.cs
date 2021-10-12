using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanNormalTransactionReportResponse : SamanErrorResponse
    {
        [JsonProperty("totalRecord")]
        public int TotalRecord { get; set; }

        [JsonProperty("transactions")]
        public List<SamanNormalTransaction> Transactions { get; set; }
    }

    public class SamanNormalTransaction
    {
        public decimal Amount { get; set; }
        public bool Cancelable { get; set; }
        public bool Changeable { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        public string DestinationIbanNumber { get; set; }
        public string FactorNumber { get; set; }
        public string IbanOwnerName { get; set; }
        public string Id { get; set; }
        public DateTime IssueDate { get; set; }
        public string ReferenceId { get; set; }
        public bool Resumeable { get; set; }
        public string SourceIbanNumber { get; set; }
        public string Status { get; set; }
        public bool Suspendable { get; set; }
    }

    public enum SamanNoramlTransactionStatus
    {
        READY_FOR_PROCESS = 0,
        SUSPENDED = 0,
        CANCELED = 5,
        PROCESS_FAIL = 0,
        READY_TO_TRANSFER = 4,
        TRANSFERRED = 10,
        SETTLED = 0,
        NOT_SETTLED = 0,
        REJECTED = 6
    }

    //WAIT_FOR_CUSTOMER_ACCEPT,
    //WAIT_FOR_BRANCH_ACCEPT,
    //BRANCH_REJECT,
    //READY_TO_TRANSFER,
    //SUSPEND,
    //CANCEL,
    //PROCESSED

    //{
        //"totalRecord": 0,
        //"transactions": [
            //{
            //    "amount": 0,
            //    "cancelable": true,
            //    "changeable": true,
            //    "currency": "string",
            //    "description": "string",
            //    "destinationIbanNumber": "string",
            //    "factorNumber": "string",
            //    "ibanOwnerName": "string",
            //    "id": "string",
            //    "issueDate": "2019-06-23T04:12:25.764Z",
            //    "referenceId": "string",
            //    "resumeable": true,
            //    "sourceIbanNumber": "string",
            //    "status": "لغو شده",
            //    "suspendable": true
            //}
        //]
    //}
}
