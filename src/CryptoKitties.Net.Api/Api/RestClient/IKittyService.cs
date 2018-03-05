using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Api.RestClient.Messages;

namespace CryptoKitties.Net.Api.RestClient
{
    /// <summary>
    /// The <see cref="IKittyService"/> contains kitty methods.
    /// </summary>
    public interface IKittyService
    {
        /// <summary>
        /// Queries all kitties.
        /// </summary>
        /// <param name="request">A <see cref="KittyQueryRequestMessage"/> containing query paramters.</param>
        /// <returns>A <see cref="KittyQueryResponseMessage"/> containing response data.</returns>
        Task<KittyQueryResponseMessage> GetKitties(KittyQueryRequestMessage request);
        /// <summary>
        /// Loads a specific kitty by id.
        /// </summary>
        /// <param name="id">A <see cref="long"/> containing the kitty id.</param>
        /// <returns>The <see cref="Kitty"/>.</returns>
        Task<Kitty> GetKitty(long id);
    }
}