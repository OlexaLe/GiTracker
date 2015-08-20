using System.Net.Http;
using System.Collections.Generic;

namespace GiTracker
{
    public interface IGitsProvider
    {
        HttpClient CreateHttpClient();

        string Host { set; }

        string RequestURL (string relativeUrl, Dictionary<string, string> parameters);

        string RequestURL (string relativeUrl);

        StringContent Content (object parameters);
    }
}

