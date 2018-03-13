using Nethereum.Contracts;
using Nethereum.JsonRpc.Client;
using Nethereum.RPC;
using Nethereum.RPC.TransactionManagers;

namespace CryptoKitties.Net.Blockchain
{
    /// <summary>
    /// The <see cref="IWeb3Client"/> interface exposes <see cref="Nethereum.Web3.Web3"/> capabilities via a dependency-injection friendly interface.
    /// </summary>
    /// <seealso cref="Nethereum.Web3.Web3"/>
    public interface IWeb3Client
    {
        ShhApiService Shh { get; }
        EthApiContractService Eth { get; }
        IClient Client { get; }
        ITransactionManager TransactionManager { get; }
        PersonalApiService Personal { get; }
        NetApiService Net { get; }
    }
}