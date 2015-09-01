using System.Net.Http;
using System.Collections.Generic;

namespace GiTracker.Services.HttpClientProvider
{
    public interface IGitsProvider
    {
        HttpClient CreateHttpClient();

        string Host { set; }

        string RequestUrl (string relativeUrl, Dictionary<string, string> parameters);

        string RequestUrl(string relativeUrl);

        StringContent Content (object parameters);
    }
}

