using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OKESA.PaymentService.Saman.PAYA.Models
{
    public class SamanDepositReportResponse : SamanErrorResponse
    {
        [JsonProperty("statements")]
        public List<SamanDepositStatement> Statements { get; set; }
    }

    public class SamanDepositStatement
    {
        [JsonProperty("agentBranchCode")]
        public string AgentBranchCode { get; set; }

        [JsonProperty("agentBranchName")]
        public string AgentBranchName { get; set; }

        [JsonProperty("balance")]
        public decimal Balance { get; set; }

        [JsonProperty("branchCode")]
        public string BranchCode { get; set; }

        [JsonProperty("branchName")]
        public string BranchName { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("referenceNumber")]
        public string ReferenceNumber { get; set; }

        [JsonProperty("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [JsonProperty("serial")]
        public int Serial { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("transferAmount")]
        public decimal TransferAmount { get; set; }
    }

    //{
        //"statements": [
            //{
            //    "agentBranchCode": "string",
            //    "agentBranchName": "string",
            //    "balance": 0,
            //    "branchCode": "string",
            //    "branchName": "string",
            //    "date": "2019-06-22T12:07:51.647Z",
            //    "description": "string",
            //    "referenceNumber": "string",
            //    "registrationNumber": "string",
            //    "serial": 0,
            //    "serialNumber": "string",
            //    "transferAmount": 0
            //}
        //]
    //}
}
