using System.Threading.Tasks;
using CryptoKitties.Net.Api.Services.Messages;

namespace CryptoKitties.Net.Api.Services
{
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


        public async Task<AuctionQueryResponseMessage> GetAuctions(AuctionQueryRequestMessage request)
        {
            return await _requestFactory.ServiceGet<AuctionQueryResponseMessage>(MethodUrl, request);
        }
        /// <summary>
        /// Relative url of auction query method
        /// </summary>
        private const string MethodUrl = "auctions";
    }
 
}
