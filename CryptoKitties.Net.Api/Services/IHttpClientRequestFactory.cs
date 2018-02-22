using System.Collections.Generic;
using System.Net;

namespace CryptoKitties.Net.Api.Services
{
    public interface IHttpClientRequestFactory
    {
        HttpWebRequest CreateRequest(string url, IDictionary<string, string> queryParameters);
    }
}