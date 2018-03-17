using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CryptoKitties.Net.Api;
using CryptoKitties.Net.Blockchain.Models;
using CryptoKitties.Net.Blockchain.RestClient.Messages;

namespace CryptoKitties.Net.Blockchain.RestClient
{
    using Settings = Properties.Settings;
    public class EtherscanApiClient : IEtherscanApiClient
    {
        public EtherscanApiClient(
            IHttpClientRequestFactory requestFactory = default(IHttpClientRequestFactory)
            )
        {
            Guard.NotNull(requestFactory, nameof(requestFactory));
            RequestFactory = requestFactory;
        }
        protected IHttpClientRequestFactory RequestFactory { get; }

        private string _apiKey;
        public virtual EtherscanApiClient SetApiKey(string key)
        {
            _apiKey = key;
            return this;
        }
        protected string ApiUrl => Settings.Default.EtherscanApiUri;

        public virtual async Task<EtherscanResponseMessage<IEnumerable<Transaction>>> GetTransactions(TransactionQueryRequestMessage request)
        {
            return await RequestFactory.ServiceGet<EtherscanResponseMessage<IEnumerable<Transaction>>>(ApiUrl, Setup(request));
        }




        protected TRequestMessage Setup<TRequestMessage>()
            where TRequestMessage : EtherscanApiRequestMessageBase, new()
        {
            var ret = new TRequestMessage();
            Setup(ret);
            return ret;
        }

        protected TRequestMessage Setup<TRequestMessage>(TRequestMessage message)
            where TRequestMessage : EtherscanApiRequestMessageBase
        {
            message.ApiKey(_apiKey);
            return message;
        }
    }
}
