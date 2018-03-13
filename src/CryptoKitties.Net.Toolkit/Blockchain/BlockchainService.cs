using CryptoKitties.Net.Api.Models;
using Org.BouncyCastle.Math;
using System;
using System.Threading.Tasks;
using CryptoKitties.Net.Api;
using Nethereum.Hex.HexTypes;

namespace CryptoKitties.Net.Blockchain
{
    public class BlockchainService
        : IBlockchainService
    {
        public BlockchainService(IWeb3Client web3)
        {
            Web3 = web3;
        }

        protected IWeb3Client Web3 { get; }

        /// <summary>
        /// Looks up summary data for <paramref name="blockId"/>.
        /// </summary>
        /// <param name="blockId">The target block identifier.</param>
        /// <returns>A <see cref="BlockSummary"/> describing the requested block.</returns>
        public async Task<BlockSummary> LookupSummary(BigInteger blockId)
        {
            var block = await Web3.Eth.Blocks.GetBlockWithTransactionsByNumber.SendRequestAsync(new HexBigInteger(blockId.ToString(16)));        
            return block == null ? default(BlockSummary) : new BlockSummary
            {
                Id = blockId,
                Hash = new BigInteger(block.BlockHash)
            };
        }

    }
}
