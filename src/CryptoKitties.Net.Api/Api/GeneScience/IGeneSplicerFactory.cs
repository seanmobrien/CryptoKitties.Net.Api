using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Api.GeneScience
{
    /// <summary>
    /// The <see cref="IGeneSplicerFactory"/> interface defines methods used to slice kitties genes.
    /// </summary>
    public interface IGeneSplicerFactory
    {
        /// <summary>
        /// Creates a new <see cref="IGeneSplicer"/> for <paramref name="genes"/>
        /// </summary>
        /// <param name="genes">A <see cref="BigInteger"/> containing genes to splice.</param>
        /// <returns>An object that implements <see cref="IGeneSplicer"/>.</returns>
        IGeneSplicer Create(BigInteger genes);
    }
}