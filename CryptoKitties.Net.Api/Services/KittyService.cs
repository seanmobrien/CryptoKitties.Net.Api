using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Api.Services.Messages;

namespace CryptoKitties.Net.Api.Services
{
    public class KittyService : IKittyService
    {
        public KittyService(IHttpClientRequestFactory requestFactory = default(IHttpClientRequestFactory))
        {
            _requestFactory = requestFactory ?? new HttpClientRequestFactory();
        }
        /// <summary>
        /// Injected <see cref="IHttpClientRequestFactory"/> instance.
        /// </summary>
        private readonly IHttpClientRequestFactory _requestFactory;


        public async Task<KittyQueryResponseMessage> GetKitties(KittyQueryRequestMessage request)
        {
            return await _requestFactory.ServiceGet<KittyQueryResponseMessage>(QueryMethodUrl, request);
        }

        public async Task<Kitty> GetKitty(long id)
        {
            return await _requestFactory.ServiceGet<Kitty>($"{QueryMethodUrl}/{id}");
        }

        /// <summary>
        /// Relative url of auction query method
        /// </summary>
        private const string QueryMethodUrl = "kitties";
    }
}
