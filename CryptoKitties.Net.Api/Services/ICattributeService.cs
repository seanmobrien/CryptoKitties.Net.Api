using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Api.Services.Messages;

namespace CryptoKitties.Net.Api.Services
{
    /// <summary>
    /// The <see cref="ICattributeService"/> defines methods used to read cattribute data.
    /// </summary>
    public interface ICattributeService
    {
        /// <summary>
        /// Reads <see cref="CattributeInfo"/>.
        /// </summary>
        /// <param name="request">A <see cref="CattributeQueryRequestMessage"/> containing query parameters.</param>
        /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="CattributeInfo"/></returns>
        Task<IEnumerable<CattributeInfo>> GetCattributes(CattributeQueryRequestMessage request);
    }
}