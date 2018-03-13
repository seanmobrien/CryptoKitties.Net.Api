using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;

namespace CryptoKitties.Net.Api.RestClient
{
    /// <summary>
    /// The <see cref="UserService"/> implements <see cref="IUserService"/> by calling cryptokittties api.
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// Creates a new <see cref="UserService"/>
        /// </summary>
        /// <param name="requestFactory">The injectable <see cref="IHttpClientRequestFactory"/>.</param>
        public UserService(IHttpClientRequestFactory requestFactory = default(IHttpClientRequestFactory))
        {
            _requestFactory = requestFactory ?? new HttpClientRequestFactory();
        }
        /// <summary>
        /// Injected <see cref="IHttpClientRequestFactory"/> instance.
        /// </summary>
        private readonly IHttpClientRequestFactory _requestFactory;
        /// <inheritdoc cref="IUserService.GetUser"/>
        public async Task<Profile> GetUser(string walletAddress)
        {
            Guard.NotWhitespace(walletAddress, nameof(walletAddress));
            var url = new StringBuilder(ServicesExtensions.KittyApiRootUrl).Append(MethodUrl).Append(walletAddress);
            return await _requestFactory.ServiceGet<Profile>(url.ToString());
        }
        /// <summary>
        /// Relative url of auction query method
        /// </summary>
        private const string MethodUrl = "user/";
    }
}
