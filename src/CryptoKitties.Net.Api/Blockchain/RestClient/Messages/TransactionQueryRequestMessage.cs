using System;
using System.Collections.Generic;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Blockchain.RestClient.Messages
{
    /// <summary>
    /// Trasaction query
    /// </summary>
    public class TransactionQueryRequestMessage
        : QueryRequestMessageBase
    {
        public TransactionQueryRequestMessage(string address, string action = default(string), string module = default(string))
            : base(module ?? Modules.Account, action ?? Actions.TxList)
        {
            Address = address;
        }
        public string Address { get; }
        public long? StartBlock { get; set; }
        public long? EndBlock { get; set; }

        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            base.WriteToQueryDictionary(target);
            SetValue(target, "address", Address);
            SetValue(target, "startblock", StartBlock);
            SetValue(target, "endblock", EndBlock);
        }


        internal static class Actions
        {
            public const string TxList = "txlist";
            public const string InternalTxList = "txlistinternal";
        }
    }
    /// <summary>
    /// Extends <see cref="TransactionQueryRequestMessage"/> to specify internal transactions should be returned.
    /// </summary>
    /// <seealso cref="TransactionQueryRequestMessage"/>
    public class InternalTransactionQueryRequestMessage
        : TransactionQueryRequestMessage
    {
        public InternalTransactionQueryRequestMessage(string address)
            : base(address, Actions.InternalTxList)
        {
            
        }
    }
}
