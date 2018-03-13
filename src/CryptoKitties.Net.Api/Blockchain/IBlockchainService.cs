using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Blockchain
{
    /// <summary>
    /// The <see cref="IBlockchainService"/> interface defines methods used to interact with the blockchain.
    /// </summary>
    public interface IBlockchainService
    {
        Task<BlockSummary> LookupSummary(BigInteger blockId);
    }
}