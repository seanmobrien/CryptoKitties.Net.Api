using System;
using System.Runtime.Serialization;

namespace CryptoKitties.Net.Blockchain.RestClient.Messages
{
    /// <summary>
    /// Contains data stored in an Ethereum log recond.
    /// </summary>
    [DataContract]
    public class LogRecord
    {
        /// <summary>
        /// The address of the contract responsible for creating the log message.
        /// </summary>
        [DataMember(Name="address")]
        public string Address { get; set; }
        /// <summary>
        /// Log topics.
        /// </summary>
        [DataMember(Name = "topics")]
        public string[] Topics { get; set; }
        /// <summary>
        /// Log Data.
        /// </summary>
        [DataMember(Name = "data")]
        public string Data { get; set; }
        /// <summary>
        /// The address of the contract responsible for creating the log message.
        /// </summary>
        [DataMember(Name = "blockNumber")]
        public string BlockNumber{ get; set; }
        /// <summary>
        /// The address of the contract responsible for creating the log message.
        /// </summary>
        [DataMember(Name = "timeStamp")]
        public string TimeStamp { get; set; }
        /// <summary>
        /// The address of the contract responsible for creating the log message.
        /// </summary>
        [DataMember(Name = "gasPrice")]
        public string GasPrice { get; set; }
        /// <summary>
        /// The address of the contract responsible for creating the log message.
        /// </summary>
        [DataMember(Name = "gasUsed")]
        public string GasUsed { get; set; }
        /// <summary>
        /// The address of the contract responsible for creating the log message.
        /// </summary>
        [DataMember(Name = "logIndex")]
        public string LogIndex { get; set; }
        /// <summary>
        /// The address of the contract responsible for creating the log message.
        /// </summary>
        [DataMember(Name = "transactionHash")]
        public string TransactionHash { get; set; }
        /// <summary>
        /// The address of the contract responsible for creating the log message.
        /// </summary>
        [DataMember(Name = "transactionIndex")]
        public string TransactionIndex { get; set; }
    }
}
