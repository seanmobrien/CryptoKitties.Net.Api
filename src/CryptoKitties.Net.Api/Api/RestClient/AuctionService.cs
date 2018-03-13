using System.Threading.Tasks;
using CryptoKitties.Net.Api.RestClient.Messages;

namespace CryptoKitties.Net.Api.RestClient
{
    /// <summary>
    /// The <see cref="AuctionService"/> class implements <see cref="IAuctionService"/> via the CryptoKitty api.
    /// </summary>
    /// <seealso cref="IAuctionService"/>
    public class AuctionService : IAuctionService
    {
        public AuctionService(IHttpClientRequestFactory requestFactory = default(IHttpClientRequestFactory))
        {
            _requestFactory = requestFactory ?? new HttpClientRequestFactory();
        }
        /// <summary>
        /// Injected <see cref="IHttpClientRequestFactory"/> instance.
        /// </summary>
        private readonly IHttpClientRequestFactory _requestFactory;

        // <inheritdoc cref="IAuctionService.GetAuctions"/>
        public async Task<AuctionQueryResponseMessage> GetAuctions(AuctionQueryRequestMessage request)
        {
            return await _requestFactory.ServiceGet<AuctionQueryResponseMessage>(ServicesExtensions.KittyApiRootUrl + MethodUrl, request);
        }
        /// <summary>
        /// Relative url of auction query method
        /// </summary>
        private const string MethodUrl = "auctions";
    }
 
}
