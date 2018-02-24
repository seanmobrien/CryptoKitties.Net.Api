using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace CryptoKitties.Net.Api.RestClient
{
    public class HttpClientRequestFactory
        : IHttpClientRequestFactory
    {
        public HttpWebRequest CreateRequest(string url, IDictionary<string, string> queryParameters)
        {
            var uriBuilder = new StringBuilder(url);
            var query = (queryParameters ?? new Dictionary<string, string>())
                .Aggregate(new StringBuilder(),
                    (sb, kvp) => sb.Append(HttpUtility.UrlEncode(kvp.Key)).Append("=").Append(HttpUtility.UrlEncode(kvp.Value)).Append("&"));
            if (query.Length > 0)
            {
                uriBuilder.Append("?").Append(query.ToString(0, query.Length - 1));
            }
            var ret = WebRequest.CreateHttp(uriBuilder.ToString());
            return ret;
        }
    }
}
