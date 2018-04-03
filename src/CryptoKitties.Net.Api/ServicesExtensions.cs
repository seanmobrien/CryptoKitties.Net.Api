using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using CryptoKitties.Net.Api;
using CryptoKitties.Net.Api.RestClient.Messages;
using Newtonsoft.Json;
using Org.BouncyCastle.Math;

namespace CryptoKitties.Net
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
            var req = instance.CreateRequest(uri, queryString);
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
                    var data = ReadResponseStream(response);
                    try
                    {
                        return JsonConvert.DeserializeObject<TResult>(data);
                    }
                    catch (JsonSerializationException jex)
                    {
                        // Note this likely means an error response was returned; we should parse and throw an informative error
                        var ex = new InvalidOperationException("Unexpected failure parsing response", jex);
                        ex.Data["JSON"] = data;
                        throw ex;
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

        static string ReadResponseStream(HttpWebResponse response)
        {
            var stream = response.GetResponseStream();
            if (stream == null) throw new InvalidOperationException();
            using (var streamReader = new StreamReader(stream, Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        /// <summary>
        /// Converts a <see cref="BigInteger"/> to a binary string.
        /// </summary>
        /// <param name="bigint">A <see cref="BigInteger"/>.</param>
        /// <returns>
        /// A <see cref="System.String"/> containing a binary
        /// representation of the supplied <see cref="BigInteger"/>.
        /// </returns>
        public static string ToBinaryString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var idx = bytes.Length - 1;

            // Create a StringBuilder having appropriate capacity.
            var base2 = new StringBuilder(bytes.Length * 8);

            // Convert first byte to binary.
            var binary = Convert.ToString(bytes[idx], 2);

            // Ensure leading zero exists if value is positive.
            if (binary[0] != '0' && bigint.SignValue == 1)
            {
                base2.Append('0');
            }

            // Append binary string to StringBuilder.
            base2.Append(binary);

            // Convert remaining bytes adding leading zeros.
            for (idx--; idx >= 0; idx--)
            {
                var bits = Convert.ToString(bytes[idx], 2);
                var part = bits.PadLeft(8, '0');
                base2.Append(part);
            }

            return base2.ToString();
        }


        /// <summary>
        /// Converts a <see cref="BigInteger"/> to a binary string.
        /// </summary>
        /// <param name="bigint">A <see cref="BigInteger"/>.</param>
        /// <returns>
        /// A <see cref="System.String"/> containing a binary
        /// representation of the supplied <see cref="BigInteger"/>.
        /// </returns>
        public static string ToUnsignedBinaryString(this BigInteger bigint)
        {
            var bytes = bigint.ToByteArray();
            var idx = 0;

            // Create a StringBuilder having appropriate capacity.
            var base2 = new StringBuilder(bytes.Length * 8);

            // Convert first byte to binary.
            var binary = Convert.ToString(bytes[idx], 2);
            /*

            // Ensure leading zero exists if value is positive.
            if (binary[0] != '0' && bigint.SignValue == 1)
            {
                base2.Append('0');
            }

            */
            // Append binary string to StringBuilder.
            base2.Append(binary);

            // Convert remaining bytes adding leading zeros.
            for (idx++; idx < bytes.Length; idx++)
            {
                var bits = Convert.ToString(bytes[idx], 2);
                var part = bits.PadLeft(8, '0');
                base2.Append(part);
            }

            return base2.ToString();
        }

        /// <summary>
        /// Root cryptokitty url.
        /// </summary>
        public const string KittyApiRootUrl = "https://api.cryptokitties.co/";
    }
}
