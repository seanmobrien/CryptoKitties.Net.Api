using CryptoKitties.Net.Api.Models;
using Org.BouncyCastle.Math;
using System;
using System.Threading.Tasks;

namespace CryptoKitties.Net.Api.Blockchain
{
    public class BlockchainService
        : IBlockchainService
    {
        public BlockchainService(IHttpClientRequestFactory httpClientFactory)
        {

        }
        /// <summary>
        /// Looks up summary data for <paramref name="blockId"/>.
        /// </summary>
        /// <param name="blockId">The target block identifier.</param>
        /// <returns>A <see cref="BlockSummary"/> describing the requested block.</returns>
        public Task<BlockSummary> LookupSummary(BigInteger blockId)
        {
            throw new NotImplementedException();
        }

    }
    public interface IBlockchainService
    {
        Task<BlockSummary> LookupSummary(BigInteger blockId);
    }
}
