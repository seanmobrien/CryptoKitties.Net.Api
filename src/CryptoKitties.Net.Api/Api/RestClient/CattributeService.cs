using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.Models;
using CryptoKitties.Net.Api.RestClient.Messages;

namespace CryptoKitties.Net.Api.RestClient
{
    /// <summary>
    /// The <see cref="CattributeService"/> implements <see cref="ICattributeService"/> by calling cryptokittties api.
    /// </summary>
    public class CattributeService : ICattributeService
    {
        public CattributeService(IHttpClientRequestFactory requestFactory = default(IHttpClientRequestFactory))
        {
            _requestFactory = requestFactory ?? new HttpClientRequestFactory();
        }
        /// <summary>
        /// Injected <see cref="IHttpClientRequestFactory"/> instance.
        /// </summary>
        private readonly IHttpClientRequestFactory _requestFactory;

        /// <inheritdoc cref="ICattributeService.GetCattributes"/>
        public async Task<IEnumerable<CattributeInfo>> GetCattributes(CattributeQueryRequestMessage request)
        {
            return await _requestFactory.ServiceGet<CattributeInfo[]>(ServicesExtensions.KittyApiRootUrl + MethodUrl, request);
        }
        /// <summary>
        /// Relative url of auction query method
        /// </summary>
        private const string MethodUrl = "cattributes";
    }
}
