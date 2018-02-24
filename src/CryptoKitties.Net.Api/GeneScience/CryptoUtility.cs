using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Org.BouncyCastle.Crypto.Digests;

namespace CryptoKitties.Net.Api.GeneScience
{
    /// <summary>
    /// The <see cref="CryptoUtility"/> class contains global cryptographic methods
    /// </summary>
    public static class CryptoUtility
    {
        /// <summary>
        /// Generates a SHA-3 hash of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The data to hash.</param>
        /// <returns>The hashed result.</returns>
        public static byte[] Sha3Keccack(this IEnumerable<byte> value)
        {
            var data = value.ToArray();
            return Sha3Keccack((byte[]) data);
        }

        /// <summary>
        /// Generates a SHA-3 hash of <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The data to hash.</param>
        /// <returns>The hashed result.</returns>
        public static byte[] Sha3Keccack(this byte[] value)
        {
            var digest = new KeccakDigest(256);
            var output = new byte[digest.GetDigestSize()];
            digest.BlockUpdate(value, 0, value.Length);
            digest.DoFinal(output, 0);
                    
            return output;
        }

        /// <summary>
        /// Reads an <see cref="int"/> value from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">A <see cref="byte"/> array storing a big-endian <see cref="int"/></param>
        /// <returns>The <see cref="int"/> equivalent to <paramref name="value"/>.</returns>
        public static Int32 BigEndianBytesToInt32(this byte[] value)
        {
            // If underlying architecture is little endian then reverse input, otherwise we will process it correctly natively
            byte[] data = ForceBigEndian(value);
            return BitConverter.ToInt32(data, 0);
        }

        /// <summary>
        /// Reads a <see cref="long"/> value from <paramref name="value"/>.
        /// </summary>
        /// <param name="value">A <see cref="byte"/> array storing a big-endian <see cref="long"/></param>
        /// <returns>The <see cref="long"/> equivalent to <paramref name="value"/>.</returns>
        public static Int64 BigEndianBytesToInt64(this byte[] value)
        {
            // If underlying architecture is little endian then reverse input, otherwise we will process it correctly natively
            byte[] data = ForceBigEndian(value);
            return BitConverter.ToInt64(data, 0);
        }

        /// <summary>
        /// Stores <paramref name="value"/> as a big-endian byte array.
        /// </summary>
        /// <param name="value">The <see cref="int"/> to store.</param>
        /// <returns>The serialized <see cref="byte"/> array.</returns>
        public static byte[] ToBigEndianBytes(this Int32 value)
        {
            return ForceBigEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Stores <paramref name="value"/> as a big-endian byte array.
        /// </summary>
        /// <param name="value">The <see cref="long"/> to store.</param>
        /// <returns>The serialized <see cref="byte"/> array.</returns>
        public static byte[] ToBigEndianBytes(this Int64 value)
        {
            return ForceBigEndian(BitConverter.GetBytes(value));
        }

        /// <summary>
        /// Reverses input if underlying archetechture is Little Endian.
        /// </summary>
        /// <param name="input">The <see cref="byte"/> array to normalize.</param>
        /// <returns>Normalized for processing by big endian architectures.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte[] ForceBigEndian(byte[] input)
        {
            return BitConverter.IsLittleEndian ? input.Reverse().ToArray() : input;
        }
    }

}
