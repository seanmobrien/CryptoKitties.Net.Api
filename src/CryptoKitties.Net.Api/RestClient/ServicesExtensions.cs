using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api.RestClient.Messages;
using Newtonsoft.Json;

namespace CryptoKitties.Net.Api.RestClient
{
    using Res = Properties.Resources;
    /// <summary>
    /// The <see cref="ServicesExtensions"/> class extends the <c>CryptoKitties.Net.Api.Services</c> namespace.
    /// </summary>
    public static class ServicesExtensions
    {
        /// <summary>
        /// Uses <paramref name="instance"/> to call <paramref name="uri"/> via a HTTP GET and serializes the response.
        /// </summary>
        /// <typeparam name="TResult">Type of response value</typeparam>
        /// <param name="instance">The <see cref="IHttpClientRequestFactory"/> being extended.</param>
        /// <param name="uri">Relative uri of the service to call</param>
        /// <param name="query">A <see cref="RequestMessageBase"/> used to build query parameters.</param>
        /// <param name="queryString">An optional <see cref="IDictionary{TKey,TValue}"/> containing additional query parameters.</param>
        /// <returns>The resulting <typeparamref name="TResult"/>.</returns>
        /// <exception cref="WebException">Thrown if the service responds with an unsuccessful response.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the service returns a null response.</exception>
        public static async Task<TResult> ServiceGet<TResult>(this IHttpClientRequestFactory instance, string uri, RequestMessageBase query,
            IDictionary<string, string> queryString = default(IDictionary<string, string>))
            where TResult : class
        {
            queryString = query?.ToQueryDictionary(queryString) ?? throw new ArgumentNullException(nameof(query));
            return await ServiceGet<TResult>(instance, uri, queryString);
        }
        /// <summary>
        /// Uses <paramref name="instance"/> to call <paramref name="uri"/> via a HTTP GET and serializes the response.
        /// </summary>
        /// <typeparam name="TResult">Type of response value</typeparam>
        /// <param name="instance">The <see cref="IHttpClientRequestFactory"/> being extended.</param>
        /// <param name="uri">Relative uri of the service to call</param>
        /// <param name="queryString">An optional <see cref="IDictionary{TKey,TValue}"/> containing additional query parameters.</param>
        /// <returns>The resulting <typeparamref name="TResult"/>.</returns>
        /// <exception cref="WebException">Thrown if the service responds with an unsuccessful response.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the service returns a null response.</exception>
        public static async Task<TResult> ServiceGet<TResult>(this IHttpClientRequestFactory instance, string uri,
            IDictionary<string, string> queryString = default(IDictionary<string, string>))
            where TResult : class
        {
            if (instance == null) throw new ArgumentNullException(nameof(instance));
            var req = instance.CreateRequest(ApiRootUrl + uri, queryString);
            req.Method = "GET";

            try
            {
                using (var response =
                    await Task.Factory.FromAsync(req.BeginGetResponse, req.EndGetResponse, req) as HttpWebResponse)
                {
                    if (response == null) throw new InvalidOperationException(Res.NullResponseDetected);
                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        return default(TResult);
                    }
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new WebException(response.StatusDescription);
                    }
                    using (var stream = response.GetResponseStream())
                    {
                        if (stream == null) throw new InvalidOperationException(Res.NullResponseDetected);
                        var serializer = new JsonSerializer();
                        return serializer.Deserialize<TResult>(
                            new JsonTextReader(new StreamReader(stream, Encoding.UTF8)));
                    }
                }
            }
            catch (WebException wex)
            {
                var httpWebResponse = wex.Response as HttpWebResponse;
                if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }
        /// <summary>
        /// Root cryptokitty url.
        /// </summary>
        public const string ApiRootUrl = "https://api.cryptokitties.co/";
    }
}
