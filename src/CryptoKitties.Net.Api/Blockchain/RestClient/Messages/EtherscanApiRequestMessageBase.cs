using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.RestClient.Messages;

namespace CryptoKitties.Net.Blockchain.RestClient.Messages
{
    public abstract class EtherscanApiRequestMessageBase
        : RequestMessageBase
    {
        protected EtherscanApiRequestMessageBase(string module, string action)
        {
            Module = module;
            Action = action;
        }

        public EtherscanApiRequestMessageBase ApiKey(string key)
        {
            _apiKey = key;
            return this;
        }

        private string _apiKey;
        public string Module { get; }
        public string Action { get; }

        /// <inheritdoc cref="WriteToQueryDictionary"/>
        protected override void WriteToQueryDictionary(IDictionary<string, string> target)
        {
            SetValue(target, "module", Module);
            SetValue(target, "action", Action);
            SetValue(target, "apikey", _apiKey);
        }


        internal static class Modules
        {
            public const string Account = "account";
        }
    }
}
