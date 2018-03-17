using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoKitties.Net.Blockchain.Models;
using CryptoKitties.Net.Blockchain.RestClient.Messages;

namespace CryptoKitties.Net.Blockchain.RestClient
{
    public interface IEtherscanApiClient
    {
        Task<EtherscanResponseMessage<IEnumerable<Transaction>>> GetTransactions(TransactionQueryRequestMessage request);
    }
}