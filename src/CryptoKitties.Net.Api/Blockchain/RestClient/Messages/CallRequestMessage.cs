using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CryptoKitties.Net.Blockchain.RestClient.Messages
{
    public class CallRequestMessage
        : EtherscanApiRequestMessageBase
    {
        public CallRequestMessage()
            : base(Modules.Proxy, Actions.Call)
        {
            
        }
        /// <summary>
        /// Contract address to call
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Data is the sha3 of the function name + parameter types + encoded parameter values
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Tag
        /// </summary>
        public string Tag { get; set; }



        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            base.WriteToQueryDictionary(target);
            SetValue(target, "to", To);
            SetValue(target, "data", Data);
            SetValue(target, "tag", Tag);
        }



        internal static class Actions
        {
            public const string Call = "eth_call";
        }

    }
}
