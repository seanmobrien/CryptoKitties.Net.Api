using System.Runtime.Serialization;

namespace CryptoKitties.Net.Blockchain.Models
{
    /// <summary>
    /// The <see cref="Transaction"/> class is used to describe a transaction stored on the Ethereum blockchain.
    /// </summary>
    [DataContract]
    public class Transaction
    {
        [DataMember(Name = "blockNumber")]
        public long BlockNumber { get; set; }
        [DataMember(Name = "timeStamp")]
        public long Timestamp { get; set; }
        [DataMember(Name = "hash")]
        public string Hash { get; set; }
        [DataMember(Name = "nonce")]
        public long Nonce { get; set; }
        [DataMember(Name = "blockHash")]
        public string BlockHash { get; set; }
        [DataMember(Name = "transactionIndex")]
        public long TransactionIndex { get; set; }
        [DataMember(Name = "from")]
        public string From { get; set; }
        [DataMember(Name = "to")]
        public string To { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
        [DataMember(Name = "gas")]
        public long Gas { get; set; }
        [DataMember(Name = "gasPrice")]
        public long GasPrice { get; set; }
        [DataMember(Name = "gasUsed")]
        public long GasUsed{ get; set; }
        [DataMember(Name = "cumulativeGasUsed")]
        public long CumulativeGasUsed { get; set; }
        [DataMember(Name = "isError")]
        public string IsError { get; set; }
        [DataMember(Name = "txreceipt_status")]
        public int ReceiptStatus { get; set; }
        [DataMember(Name = "input")]
        public string Input { get; set; }
        [DataMember(Name = "contractAddress")]
        public string ContractAddress { get; set; }
        [DataMember(Name = "confirmations")]
        public long Confirmations { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "traceId")]
        public string TraceId { get; set; }
        [DataMember(Name = "errCode")]
        public string ErrorCode { get; set; }
    }
}