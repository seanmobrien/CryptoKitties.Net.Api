﻿using System;
using System.Collections.Generic;
using System.Linq;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Api.GeneScience
{
    /// <summary>
    /// The <see cref="GeneScienceUtilities"/> class contains a simulation of the offical Gene Science algorithm implemented by the smart contract.
    /// </summary>
    public static class GeneScienceUtilities
    {
        /// <summary>
        /// Creates a new <see cref="IGeneSplicer"/> given <paramref name="genesInHex"/>
        /// </summary>
        /// <param name="instance">The <see cref="IGeneSplicerFactory"/> being extended.</param>
        /// <param name="genesInHex">A <see cref="string"/> expressing source genese in hex</param>
        /// <returns>An object that implements <see cref="IGeneSplicer"/></returns>
        public static IGeneSplicer Create(this IGeneSplicerFactory instance, string genesInHex)
        { return instance.Create(new BigInteger(genesInHex, 16)); }
        /// <summary>
        /// Raw genescience algorithm as tranlated by https://github.com/heglex/gene-science
        /// </summary>
        /// <param name="matron"></param>
        /// <param name="sire"></param>
        /// <param name="matronCooldownEndBlock"></param>
        /// <param name="cooldownBlockHash"></param>
        /// <returns></returns>
        public static BigInteger SimulateOffspring(BigInteger matron, BigInteger sire, BigInteger matronCooldownEndBlock, BigInteger cooldownBlockHash)
        {
            // concatenate bytes arrays - blockhashes + matronGenes + sireGenes + matronCooldownEndBlock
            var alls = new List<byte>();
            AppendBytes(alls, cooldownBlockHash);
            AppendBytes(alls, matron);
            AppendBytes(alls, sire);
            AppendBytes(alls, matronCooldownEndBlock);

            // get hash of bytes arrays as a big-ol' (big-endian?) int
            // hash = sha3.keccak_256(alls);  hash = int.from_bytes(hash.digest(), byteorder = 'big')            
            var hash = new BigInteger(1, alls.Sha3Keccack());

            // Get 5-bit chunks of matron and sire             
            var matronMask = MaskGenes(matron);
            var sireMask = MaskGenes(sire);
       
            // Swap dom/rec gene traits in parents
            var hashindex = SwapParentGenes(hash, matronMask, sireMask);
            // combine genes from swapped parent genes, introducing mutations
            var outmasks = MutateGenes(hash, hashindex, matronMask, sireMask);
            
            // this is where we will accumulate the calculated child genes
            var outs = BigInteger.Zero;
            for (var cnt = 0; cnt < 0x30; cnt++)
            {
                var part = BigInteger.ValueOf(outmasks[cnt]).ShiftLeft(5 * cnt);
                outs = outs.Or(part);
            }
            return outs;
        }
        /// <summary>
        /// Extracts gene mask from <paramref name="genes"/>.
        /// </summary>
        /// <param name="genes"></param>
        /// <returns>The masked genepool.</returns>
        private static byte[] MaskGenes(BigInteger genes)
        {
            const int count = 0x30;
            var ret = new byte[count];
            for (var idx = 0; idx < count; idx++)
            {
                ret[idx] = GeneByteMask(genes, 5 * idx, 5);
            }
            return ret;
        }
        /// <summary>
        /// Combine genes from swapped parents, introducing mutations.
        /// </summary>
        /// <param name="hash">A <see cref="BigInteger"/> that contains the block hash.</param>
        /// <param name="hashindex">An <see cref="int"/> identifying the current hash bit.</param>
        /// <param name="matron">A <see cref="byte"/> array containing matron genes.</param>
        /// <param name="sire">A <see cref="byte"/> array containing sire genes.</param>
        /// <returns>A <see cref="List{T}"/> containing the mutation-adjusted genes of the offspring.</returns>
        private static List<byte> MutateGenes(BigInteger hash, int hashindex, byte[] matron, byte[] sire)
        {
            // combine genes from swapped parent genes, introducing mutations
            var outmasks = new List<byte>();
            for (var cnt = 0; cnt < 0x30; cnt++)
            {
                byte randoByte = 0;
                // Mutate only on dom genes
                if (cnt % 4 == 0)
                {
                    var tmp1 = matron[cnt] & 1;
                    var tmp2 = sire[cnt] & 1;
                    if (tmp1 != tmp2)
                    {
                        var maskedHash = GeneByteMask(hash, hashindex, 3);
                        hashindex += 3;
                        var mask1 = matron[cnt];
                        var mask2 = sire[cnt];
                        // mutate only if the two parent dominant genes differ by 1...
                        if (Math.Abs(mask2 - mask1) == 1)
                        {
                            // and the smaller of two is even...
                            var minMask = Math.Min(mask1, mask2);
                            if (minMask % 2 == 0)
                            {
                                bool trial;
                                if (minMask < 0x17)
                                {
                                    trial = maskedHash > 1;
                                }
                                else
                                {
                                    trial = maskedHash > 0;
                                }
                                if (!trial)
                                {
                                    // mutation is the smaller of the two parent dominant genes, divided by two, plus 16
                                    randoByte = (byte)((minMask >> 1) + 0x10);
                                }
                            }
                        }
                    }
                    if (randoByte > 0)
                    {
                        outmasks.Add(randoByte);
                        continue;
                    }
                }
                // Determine whether sire or matron should pass on gene
                var checkMask = GeneByteMask(hash, hashindex, 1);
                hashindex += 1;
                // And add to output accordingly
                outmasks.Add(checkMask == 0 ? matron[cnt] : sire[cnt]);
            }
            return outmasks;
        }
        /// <summary>
        /// Swaps dominant and recessive parent genes as dictated by <paramref name="hash"/>.
        /// </summary>
        /// <param name="hash">The hash used to provide randomness.</param>
        /// <param name="matron">A <see cref="byte"/> array containing matron genes.</param>
        /// <param name="sire">A <see cref="byte"/> array containing sire genes.</param>
        /// <param name="matron">Upon return, contains a <see cref="byte"/> array containing swapped matron genes.</param>
        /// <param name="sire">Upon return, contains a <see cref="byte"/> array containing swapped sire genes.</param>
        /// <returns>An <see cref="int"/> identifying the index of the next bits from the hash.</returns>
        private static int SwapParentGenes(BigInteger hash, byte[] matron, byte[] sire)
        {            
            //  note in worst case hashindex wont reach 256 so no need for modulo
            var hashindex = 0;
            // swap dominant/recessive genes according to masked_hash
            for (var bigcounter = 0; bigcounter < 0x0c; bigcounter++)
            {
                for (var smallcounter = 3; smallcounter > 0; smallcounter--)
                {
                    var count = 4 * bigcounter + smallcounter;
                    hashindex = GeneSwapper(hash, hashindex, matron, count);
                    hashindex = GeneSwapper(hash, hashindex, sire, count);
                }
            }            
            return hashindex;
        }
        /// <summary>
        /// Uses <paramref name="hash"/> at <paramref name="hashindex"/> to determine if dom/res genes should be swapped, and acts accordingly.
        /// </summary>
        /// <param name="hash">The <see cref="BigInteger"/> hash.</param>
        /// <param name="hashindex">Hash index</param>
        /// <param name="target">Target gene bytes.</param>
        /// <param name="targetOffset">Offset within <paramref name="target"/> to swap.</param>
        /// <returns>Next value for <paramref name="hashindex"/>/</returns>
        private static int GeneSwapper(BigInteger hash, int hashindex, byte[] target, int targetOffset)
        {
            var masked_hash = GeneByteMask(hash, hashindex, 2);
            if (masked_hash == 0)
            {
                var bit = target[targetOffset - 1];
                target[targetOffset - 1] = target[targetOffset];
                target[targetOffset] = bit;
            }
            return hashindex + 2;
        }      
        /// <summary>
        /// Gene bytemask function extracts a gene bit from <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="BigInteger"/> containing gene data.</param>
        /// <param name="start">The offset bit</param>
        /// <param name="numberOfBytes">Number of bits.</param>
        /// <returns>The masked byte.</returns>
        private static byte GeneByteMask(BigInteger input, int start, int numberOfBytes)
        {
            // mask = 2**numbytes - 1
            var mask = BigInteger.Two.Pow(numberOfBytes).Subtract(BigInteger.One);
            // mask = mask << start
            mask = mask.ShiftLeft(start);
            var ret = input.And(mask);
            ret = ret.ShiftRight(start);
            return (byte) ret.IntValue;
        }
        private static byte[] AppendBytes(IList<byte> target, BigInteger value)
        {
            var ret = new List<byte>();
            for (var idx = 0; idx < 32; idx++)
            {
                // var res = value.Divide(BigInteger.ValueOf((long) Math.Pow(1 << 8, idx))).And(BigInteger.ValueOf(0xff));
                // arg3//((1<<8)**cnt)&0xff
                var part1 = BigInteger.ValueOf(1 << 8).Pow(idx);
                var part2 = value.Divide(part1);
                var part3 = part2.And(BigInteger.ValueOf(0xff));
                ret.Add((byte)part3.IntValue);
            }
            if (BitConverter.IsLittleEndian)
            {
                ret.Reverse();
            }
            ret.Aggregate(target, (t, x) =>
            {
                t.Add(x);
                return t;
            });
            return ret.ToArray();
        }
    }
}
