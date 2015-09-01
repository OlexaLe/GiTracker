using System.Collections.Generic;
using System.Net.Http;

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