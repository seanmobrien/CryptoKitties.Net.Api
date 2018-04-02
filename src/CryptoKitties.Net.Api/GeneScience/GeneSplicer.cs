using System.Collections.Generic;
using System.Linq;
using System.Text;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.GeneScience.Models;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.GeneScience
{
    /// <summary>
    /// The <see cref="GeneSplicer"/> class is used to splice and explore a kitty&apos;s genes.
    /// </summary>
    public class GeneSplicer
    {
        /// <summary>
        /// Initializes a new <see cref="GeneSplicer"/> instance.
        /// </summary>
        /// <param name="genes">A <see cref="BigInteger"/> contiaing the raw genes.</param>
        public GeneSplicer(BigInteger genes)
        {
            Genes = genes;
        }
        /// <summary>
        /// Initializes a new <see cref="GeneSplicer"/> instance.
        /// </summary>
        /// <param name="genes">A <see cref="GeneSplicer"/> to copy.</param>
        public GeneSplicer(GeneSplicer genes)
            : this(genes.Genes)
        { }
        /// <summary>
        /// Raw input
        /// </summary>
        public BigInteger Genes { get;  }
        /// <summary>
        /// Stores <see cref="Kai"/> value.
        /// </summary>
        private string _kai;
        /// <summary>
        /// Stores <see cref="Binary"/> value.
        /// </summary>
        private string _binary;
        /// <summary>
        /// <see cref="Genes"/> expressed as a binary string
        /// </summary>
        public string Binary => _binary = _binary ?? Genes.ToUnsignedBinaryString().PadLeft(256, '0');

        /// <summary>
        /// <see cref="Genes"/> expressed as kai notation with spaces seperating each category.
        /// </summary>
        public string Kai => NormalizeKai(RawKai);
        /// <summary>
        /// Raw kai without category breaks.
        /// </summary>
        private string RawKai => _kai = _kai ?? EncodeKai();
        /// <summary>Returns all <see cref="CattributeData"/> expressed by this <see cref="GeneSplicer"/>.</summary>
        public IEnumerable<GeneSet> AllCattributes => Globals.Cattributes.AllCategories.Select(GetGeneSet);
        /// <summary>Returns all known <see cref="CattributeData"/> expressed by this <see cref="GeneSplicer"/> (excluding Secret, Unknown, and Mystery).</summary>
        public IEnumerable<GeneSet> KnownCattributes => Globals.Cattributes.KnownCategories.Select(GetGeneSet);
        /// <summary>
        /// Returns the <see cref="GeneSet"/> expressed for <paramref name="cattributeType"/>. 
        /// </summary>
        /// <param name="cattributeType">The <see cref="CattributeType"/> to retrieve.</param>
        /// <returns>A <see cref="GeneSet"/>.</returns>
        public GeneSet GetGeneSet(CattributeType cattributeType)
        {
            var category = Globals.Cattributes.CattributeCategories[cattributeType];
            return GetGeneSet(category);
        }
        /// <summary>
        /// Returns the <see cref="GeneSet"/> expressed for <paramref name="cattributeType"/>. 
        /// </summary>
        /// <param name="category">The <see cref="CattributeCategoryData"/> to retrieve.</param>
        /// <returns>A <see cref="GeneSet"/>.</returns>
        public GeneSet GetGeneSet(CattributeCategoryData category)
        {
            var cattributes = new CattributeData[4];
            // Every 4 characters we have added a space, so we need to normalize the bit offset
            var raw = RawKai;
            for (var idx = 0; idx < 4; idx++)
            {
                var kai = raw[category.BitOffset - idx];
                cattributes[idx] = category.GetCattribute(kai);
            }
            return new GeneSet(category.Type, cattributes);
        }
        /// <summary>
        /// Encodes <see cref="Genes"/> as a Kai value.
        /// </summary>
        /// <returns>A <see cref="string"/> that contains the kai representation of the value.</returns>
        private string EncodeKai()
        {
            var binary = Binary;
            var builder = new StringBuilder();
            //var parts = 0;
            for (var idx = 21; idx <= binary.Length; idx += 5)
            {
                var part = binary.Substring(idx - 5, 5);
                builder.Append(KaiFromBits[part]);
                //if (++parts % 4 == 0) { builder.Append(" "); }
            }
            return builder.ToString();
        }
        /// <summary>
        /// Normalizes kai encoded value for human consumption
        /// </summary>
        /// <param name="input">A <see cref="string"/> containing the raw kai value to normalize</param>
        /// <returns>A <see cref="string"/> containing the normalized kai.</returns>
        private static string NormalizeKai(string input)
        {
            var len = input.Length;
            var parts = len / 4;
            var output = new StringBuilder(parts + len + 1);
            for (var idx = 0; idx < parts; idx++)
            {
                output.Append(input.Substring(idx * 4, 4))
                    .Append(" ");
            }
            return output.ToString(0, output.Length - 1);
        }
        /// <summary>
        /// Dictionary converting a string representation of 5 bits into Kai, cause I'm sick of messing around with that last bit
        /// </summary>
        private static readonly Dictionary<string, char> KaiFromBits = new Dictionary<string, char>
        {
            {"00000", '1'},
            {"00001", '2'},
            {"00010", '3'},
            {"00011", '4'},
            {"00100", '5'},
            {"00101", '6'},
            {"00110", '7'},
            {"00111", '8'},
            {"01000", '9'},
            {"01001", 'a'},
            {"01010", 'b'},
            {"01011", 'c'},
            {"01100", 'd'},
            {"01101", 'e'},
            {"01110", 'f'},
            {"01111", 'g'},
            {"10000", 'h'},
            {"10001", 'i'},
            {"10010", 'j'},
            {"10011", 'k'},
            {"10100", 'm'},
            {"10101", 'n'},
            {"10110", 'o'},
            {"10111", 'p'},
            {"11000", 'q'},
            {"11001", 'r'},
            {"11010", 's'},
            {"11011", 't'},
            {"11100", 'u'},
            {"11101", 'v'},
            {"11110", 'w'},
            {"11111", 'x'}
        };
    }
}
