using System;
using System.Collections.Generic;
using System.Linq;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Api.GeneScience
{
    public static class GeneScienceUtilities
    {
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
            var matronGenes = AppendBytes(alls, matron);
            var sireGenes = AppendBytes(alls, sire);
            AppendBytes(alls, matronCooldownEndBlock);

            // get hash of bytes arrays as a big-endian int
            // hash = sha3.keccak_256(alls);  hash = int.from_bytes(hash.digest(), byteorder = 'big')
            var hashBytesYuck = alls.Sha3Keccack();            
            // No reason to convert has to bgint is there
            var hash = new BigInteger(1, hashBytesYuck);
           

            // Get 5-bit chunks of matron and sire 
            var matronMasks = MaskGenes(matronGenes);
            var sireMasks = MaskGenes(sireGenes);
       
            // Swap dom/rec gene traits in parents
            byte[] matronMaskCopy;
            byte[] sireMaskCopy;
            var hashindex = SwapParentGenes(hash, matronMasks, out matronMaskCopy, sireMasks, out sireMaskCopy);
            // combine genes from swapped parent genes, introducing mutations
            var outmasks = new List<byte>();
            for (var cnt = 0; cnt < 0x30; cnt++)
            {
                byte randoByte = 0;
                // Mutate only on dom genes
                if (cnt % 4 == 0)
                {
                    var tmp1 = matronMaskCopy[cnt] & 1;
                    var tmp2 = sireMaskCopy[cnt] & 1;
                    if (tmp1 != tmp2)
                    {
                        var maskedHash = GeneByteMask(hash, hashindex, 3);
                        hashindex += 3;               
                        var mask1 = matronMaskCopy[cnt];
                        var mask2 = sireMaskCopy[cnt];
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
                outmasks.Add(checkMask == 0 ? matronMaskCopy[cnt] : sireMaskCopy[cnt]);                
            }
            // this is where we will accumulate the calculated child genes
            var outs = BigInteger.Zero;
            for (var cnt = 0; cnt < 30; cnt++)
            {
                outs = outs.Or(BigInteger.ValueOf(outmasks[cnt] << 5 * cnt));
            }
            return outs;
        }
        /// <summary>
        /// Swaps dominant and recessive parent genes as dictated by <paramref name="hash"/>.
        /// </summary>
        /// <param name="hash">The hash used to provide randomness.</param>
        /// <param name="matron">A <see cref="byte"/> array containing matron genes.</param>
        /// <param name="sire">A <see cref="byte"/> array containing sire genes.</param>
        /// <param name="matronGenes">Upon return, contains a <see cref="byte"/> array containing swapped matron genes.</param>
        /// <param name="sireGenes">Upon return, contains a <see cref="byte"/> array containing swapped sire genes.</param>
        /// <returns>An <see cref="int"/> identifying the index of the next bits from the hash.</returns>
        private static int SwapParentGenes(BigInteger hash, byte[] matron, out byte[] matronGenes, byte[] sire, out byte[] sireGenes)
        {
            // With working copies
            matronGenes = matron.Clone() as byte[];
            sireGenes = sire.Clone() as byte[];
            //  note in worst case hashindex wont reach 256 so no need for modulo
            var hashindex = 0;
            // swap dominant/recessive genes according to masked_hash
            for (var bigcounter = 0; bigcounter < 0x0c; bigcounter++)
            {
                for (var smallcounter = 3; smallcounter > 0; smallcounter--)
                {
                    var count = 4 * bigcounter + smallcounter;
                    // Checks out
                    // System.Diagnostics.Debug.WriteLine($"{bigcounter}    {smallcounter}    {4*bigcounter}     {count}");

                    hashindex = GeneSwapper(hash, hashindex, matronGenes, count, "matr");
                    hashindex = GeneSwapper(hash, hashindex, sireGenes, count, "sire");
                }
            }
            DumpBytes(matronGenes, "arg1maskscopy");           
            DumpBytes(sireGenes, "arg2maskscopy");
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
        private static int GeneSwapper(BigInteger hash, int hashindex, byte[] target, int targetOffset, string which)
        {
            var masked_hash = GeneByteMask(hash, hashindex, 2);

            System.Diagnostics.Debug.WriteLine($"{targetOffset} {which} {hashindex} {masked_hash}");

            if (masked_hash == 0)
            {
                var bit = target[targetOffset - 1];
                target[targetOffset - 1] = target[targetOffset];
                target[targetOffset] = bit;
            }
            return hashindex + 2;
        }

        private static byte[] MaskGenes(byte[] genes, int bits = 5, int count = 0x30)
        {
            var ret = new List<byte>(count);
            for (var idx = 0; idx < count; idx++)
            {
                ret.Add(GeneByteMask(genes, bits * idx, 5));
            }
            return ret.ToArray();
        }
        /// <summary>
        /// Gene bytemask function extracts a gene bit from <paramref name="input"/>.
        /// </summary>
        /// <param name="input">The <see cref="BigInteger"/> containing gene data.</param>
        /// <param name="start">The offset bit</param>
        /// <param name="numberOfBytes">Number of bits.</param>
        /// <returns>The masked byte.</returns>
        [Obsolete("Try to use the BigInt version when possible")]
        private static byte GeneByteMask(byte[] input, int start, int numberOfBytes)
        {
            return GeneByteMask(new BigInteger(input), start, numberOfBytes);
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


        private static void DumpBytes(byte[] bytes, string name = default(string))
        {
            var data = bytes.Aggregate(new System.Text.StringBuilder("[ "), (sb, x) => sb.AppendFormat("{0}, ", x), sb => sb.ToString(0, sb.Length - 1) + "]");
            System.Diagnostics.Debug.WriteLine(string.Format("{0} Bytes=\r\n\t{1}", name ?? "Some", data));
        }

        /* https://github.com/heglex/gene-science
         *  These examples are from Tx 0xa7b0ac87684771f6d6204a09b5a0bf0b97f6adf61b78138e8fd264828e36b956

# matron.genes
arg1 = 0x000063169218f348dc640d171b000208934b5a90189038cb3084624a50f7316c

# sire.genes
arg2 = 0x00005a13429085339c6521ef0300011c82438c628cc431a63298e3721f772d29

# matron.cooldownEndBlock - 1
arg3 = 0x000000000000000000000000000000000000000000000000000000000047ff27

# BLOCKHASH of block number equal to arg3
blockhash = 0xf9dd4486d68b13839d2f7b345f5223f17abae39a951f2cea5b0ca0dd6dc8db83
# load arguments into bytes arrays in big-Endian order

args1 = []
for cnt in range(32):
    args1.append(arg1//((1<<8)**cnt)&0xff)
args1.reverse()
args1 = bytes(args1)

args2 = []
for cnt in range(32):
    args2.append(arg2//((1<<8)**cnt)&0xff)
args2.reverse()
args2 = bytes(args2)


args3 = []
for cnt in range(32):
    args3.append(arg3//((1<<8)**cnt)&0xff)
args3.reverse()
args3 = bytes(args3)

blockhashes = []
for cnt in range(32):
    blockhashes.append(blockhash//((1<<8)**cnt)&0xff)
blockhashes.reverse()
blockhashes = bytes(blockhashes)

            # concatenate bytes arrays

alls =  blockhashes + args1 + args2 + args3

# get hash of bytes arrays. This is your source of "randomness"

hash = sha3.keccak_256(alls)
hash = int.from_bytes(hash.digest(), byteorder = 'big')

print(hex(hash))

# get 5-bit chunks of matron and sire

def masker(arg, start, numbytes):
    mask = 2**numbytes - 1
    mask = mask << start
    out = arg & mask
    out = out >> start
    
    return out

arg1masks = []
for cnt in range(0x30):
    arg1masks.append(masker(arg1, 5*cnt, 5))
    
arg2masks = []
for cnt in range(0x30):
    arg2masks.append(masker(arg2, 5*cnt, 5))
    
arg1maskscopy = arg1masks.copy()
arg2maskscopy = arg2masks.copy()

            # note in worst case hashindex wont reach 256 so no need for modulo
hashindex = 0

# swap dominant/recessive genes according to masked_hash
for bigcounter in range(0x0c):
    for smallcounter in range(3, 0, -1):
        count = 4*bigcounter + smallcounter
        
        masked_hash = masker(hash, hashindex, 2)
        hashindex += 2
        if masked_hash == 0:
            tmp = arg1maskscopy[count - 1]
            arg1maskscopy[count - 1] = arg1maskscopy[count]
            arg1maskscopy[count] = tmp
            
        masked_hash = masker(hash, hashindex, 2)
        hashindex += 2
        if masked_hash == 0:
            tmp = arg2maskscopy[count - 1]
            arg2maskscopy[count - 1] = arg2maskscopy[count]
            arg2maskscopy[count] = tmp

# combine genes from swapped parent genes, introducing mutations
outmasks = []
for cnt in range(0x30):
    rando_byte = 0
    
    # mutate only on dominant genes
    if cnt%4 == 0:
        tmp1 = arg1maskscopy[cnt]&1
        tmp2 = arg2maskscopy[cnt]&1

        if tmp1 != tmp2:
            masked_hash = masker(hash, hashindex, 3)
            hashindex += 3
            
            mask1 = arg1maskscopy[cnt]
            mask2 = arg2maskscopy[cnt]
            
            # mutate only if the two parent dominant genes differ by 1...
            if abs(mask2 - mask1) == 1:
                min_mask = min(mask1, mask2)
                # and the smaller of the two is even...
                if min_mask % 2 == 0:
                    if min_mask < 0x17:
                        trial = masked_hash > 1
                    else:
                        trial = masked_hash > 0
                    if not trial:
                        # mutation is the smaller of the two parent dominant genes,
                        # divided by two, plus 16
                        rando_byte = (min_mask >> 1) + 0x10
        
        if rando_byte > 0:
            print(cnt)
            outmasks.append(rando_byte)
            continue
                                
    masked_hash = masker(hash, hashindex, 1)
    hashindex += 1
    
    if masked_hash == 0:
        outmasks.append(arg1maskscopy[cnt])
    else:
        outmasks.append(arg2maskscopy[cnt])
            
        # this is where we will accumulate the calculated child genes
outs = 0

# this is where you can put the known child genes, for testing
outs2 = 0x5b174298a44b9c6521176000021c53734c9018c431a73298674a5177316c

for cnt in range(0x30):
    outs |= outmasks[cnt] << 5*cnt

# print both for comparison
print(hex(outs))
print(hex(outs2))                

# or, separately print each 5-bit gene
for cnt, outmask in enumerate(outmasks):
    print(cnt, hex(outmask), hex(masker(outs2, 5*cnt, 5)))
    */


    }
}
