using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Api.RestClient.Messages;

namespace CryptoKitties.Net.Api.RestClient
{
    /// <summary>
    /// The <see cref="IUserService"/> defines methods used to read cattribute data.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Reads <see cref="CattributeInfo"/>.
        /// </summary>
        /// <param name="walletAddress">A <see cref="string"/> containing the user&apos;s wallet address.</param>
        /// <returns>A <see cref="Profile"/> describing the requested user, or <c>null</c> if no user is found.</returns>
        Task<Profile> GetUser(string walletAddress);
    }
}