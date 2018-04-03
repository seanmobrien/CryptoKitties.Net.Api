using System.Collections.Generic;
using CryptoKitties.Net.Api.GeneScience.Models;
using CryptoKitties.Net.Api.Models;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Api.GeneScience
{
    public interface IGeneSplicer
    {
        /// <summary>
        /// Raw input
        /// </summary>
        BigInteger Genes { get; }

        /// <summary>
        /// <see cref="Genes"/> expressed as a binary string
        /// </summary>
        string Binary { get; }

        /// <summary>
        /// <see cref="Genes"/> expressed as kai notation with spaces seperating each category.
        /// </summary>
        string Kai { get; }

        /// <summary>Returns all <see cref="CattributeData"/> expressed by this <see cref="GeneSplicer"/>.</summary>
        IEnumerable<GeneSet> AllCattributes { get; }

        /// <summary>Returns all known <see cref="CattributeData"/> expressed by this <see cref="GeneSplicer"/> (excluding Secret, Unknown, and Mystery).</summary>
        IEnumerable<GeneSet> KnownCattributes { get; }

        /// <summary>
        /// Returns the <see cref="GeneSet"/> expressed for <paramref name="cattributeType"/>. 
        /// </summary>
        /// <param name="cattributeType">The <see cref="CattributeType"/> to retrieve.</param>
        /// <returns>A <see cref="GeneSet"/>.</returns>
        GeneSet GetGeneSet(CattributeType cattributeType);
    }
}