using System.Net.Http;
using System.Collections.Generic;

namespace GiTracker.Services.HttpClientProvider
{
    public interface IHttpClientProvider
    {
        HttpClient CreateHttpClient();

        string GetRequestUrl(string host, string relativeUrl, Dictionary<string, string> parameters);

        string GetRequestUrl(string host, string relativeUrl);

        StringContent GetBodyContent(object parameters);
    }
}