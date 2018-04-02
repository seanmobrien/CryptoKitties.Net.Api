using System;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Blockchain
{
    using Res = Properties.Resources;
    public class ContractCallResultReader
    {
        public ContractCallResultReader(string result)
        {
            Guard.NotWhitespace(result, nameof(result));
            if (result.StartsWith("0x")) { result = result.Substring(2); }
            if (result.Length % ChunkSize != 0) throw new ArgumentOutOfRangeException(nameof(result),result, Res.ContractCallResultReader_ContractCallResultReader_Unexpected_data_length);
            _rawResult = result;
            CurrentIndex = -1;
        }

        private readonly string _rawResult;
        /// <summary>
        /// Raw call result
        /// </summary>
        public string RawResult => "0x" + _rawResult;
        /// <summary>
        /// Current index
        /// </summary>
        public int CurrentIndex { get; private set; }
        /// <summary>
        /// Number of values
        /// </summary>
        public int Count => _rawResult.Length / 64;
        /// <summary>
        /// Moves to the next offset;
        /// </summary>
        /// <returns><c>true</c> if there was a record available; otherwise, <c>false</c>.</returns>
        public bool MoveNext()
        {
            var count = Count;
            if (CurrentIndex == count) return false;
            CurrentIndex++;
            return CurrentIndex < count;
        }
        /// <summary>
        /// Current value as a <see cref="BigInteger"/>.
        /// </summary>
        public BigInteger CurrentValue => GetUint256(CurrentIndex);
        /// <summary>
        /// Current value as a bool.
        /// </summary>
        public bool CurrentBool => GetBool(CurrentIndex);

        /// <summary>
        /// Gets the raw value at offset <paramref name="index"/>.
        /// </summary>
        /// <param name="index">An <see cref="int"/> identifying the offset</param>
        /// <returns>A <see cref="string"/> containing raw data</returns>
        public string GetRawValue(int index = -1)
        {
            if (index == -1) {  index = CurrentIndex; }
            if (index < 0) throw new IndexOutOfRangeException();
            var start = index * ChunkSize;
            if (start > _rawResult.Length) throw new IndexOutOfRangeException();
            return _rawResult.Substring(start, ChunkSize);
        }
        /// <summary>
        /// Retrieves a value as a uint256 value.
        /// </summary>
        /// <param name="index">Offset of this value.</param>
        /// <returns>A <see cref="BigInteger"/>.</returns>
        public BigInteger GetUint256(int index)
        {
            return new BigInteger(GetRawValue(index), 16);
        }
        /// <summary>
        /// Retreives a value as a boolean value.
        /// </summary>
        /// <param name="index">Index of value to return.</param>
        /// <returns>A <see cref="bool"/> value.</returns>
        public bool GetBool(int index)
        {
            return int.Parse(GetRawValue(index)) == 0;
        }



        internal const int ChunkSize = 64;
    }
}
