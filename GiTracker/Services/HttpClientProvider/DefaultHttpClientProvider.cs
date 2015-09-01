using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Net.Http.Headers;

namespace GiTracker.Services.HttpClientProvider
{
    public class DefaultHttpClientProvider : IHttpClientProvider
    {
        const string UserAgent = "XamarinGarage";

        #region IHttpClientProvider implementation

        public HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            return httpClient;
        }

        public string GetRequestUrl(string host, string relativeUrl)
        {
            return GetRequestUrl(host, relativeUrl, new Dictionary<string, string>());
        }

        public string GetRequestUrl(string host, string relativeUrl, Dictionary<string, string> parameters)
        {
            var queryString = BuildParametersString(parameters);
            return $"{host}{relativeUrl}?{queryString}";
        }

        public StringContent GetBodyContent(object parameters)
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
            return new StringContent(content, Encoding.UTF8, "application/json");
        }
        #endregion

        string BuildParametersString(Dictionary<string, string> parameters)
        {
            var queryString = new StringBuilder();
            foreach (var parameter in parameters)
            {
                if (queryString.Length > 0)
                    queryString.Append('&');
                queryString.AppendFormat("{0}={1}", parameter.Key, parameter.Value);
            }
            return WebUtility.UrlEncode(queryString.ToString());
        }
    }
}

