using Nethereum.Contracts;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC;
using Nethereum.RPC.TransactionManagers;
using Nethereum.Web3;

namespace CryptoKitties.Net.Blockchain
{
    public class Web3Client : IWeb3Client
    {
        public Web3Client(Web3 inner)
        {
            Guard.NotNull(inner, nameof(inner));
            InnerClient = inner;
        }
        protected Web3 InnerClient { get; }
        public virtual ShhApiService Shh => InnerClient.Shh;
        public virtual EthApiContractService Eth => InnerClient.Eth;
        public virtual IClient Client => InnerClient.Client;
        public virtual ITransactionManager TransactionManager => InnerClient.TransactionManager;
        public virtual PersonalApiService Personal => InnerClient.Personal;
        public virtual NetApiService Net => InnerClient.Net;
    }
}
