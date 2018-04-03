using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net.Api.GeneScience
{
    /// <summary>
    /// Provides a default implementation of <see cref="IGeneSplicerFactory"/>.
    /// </summary>
    public class GeneSplicerFactory : IGeneSplicerFactory
    {
        /// <summary>
        /// Creates a new <see cref="IGeneSplicer"/> for <paramref name="genes"/>
        /// </summary>
        /// <param name="genes">A <see cref="BigInteger"/> containing genes to splice.</param>
        /// <returns>An object that implements <see cref="IGeneSplicer"/>.</returns>
        public IGeneSplicer Create(BigInteger genes)
        {
            return new GeneSplicer(genes);
        }
    }
}
