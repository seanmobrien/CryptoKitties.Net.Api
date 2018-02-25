using CryptoKitties.Net.Api.Blockchain;
using Org.BouncyCastle.Math;
using System;
using System.Threading.Tasks;

namespace CryptoKitties.Net.Api.GeneScience
{
    public class GeneScienceService
    {
        public GeneScienceService(
           IBlockchainService blocksteamService
           )
        {
            this._blockchainService = blocksteamService ?? throw new ArgumentNullException("blockstreamService");
        }

        private readonly IBlockchainService _blockchainService;


        public async Task<BigInteger> SimulateOffspring(BigInteger matron, BigInteger sire, BigInteger matronCooldownBlock)
        {
            var block = await _blockchainService.LookupSummary(matronCooldownBlock);
            if (block == null) { throw new ArgumentOutOfRangeException("matronCooldownBlock", matronCooldownBlock.ToString(), "Block id not found"); }
            return GeneScienceUtilities.SimulateOffspring(matron, sire, matronCooldownBlock, block.Hash);
        }
    }
}
