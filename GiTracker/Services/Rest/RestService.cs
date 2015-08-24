using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GiTracker.Services.Rest
{
    internal class RestService : IRestService
    {
        private const string UserAgent = "XamarinGarage";

        public async Task<object> GetAsync(string host, string url, Type responseType,
            CancellationToken cancellationToken)
        {
            using (var client = CreateHttpClient(host))
            {
                using (var response = await client.GetAsync(url, cancellationToken).ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(response.ToString());

                    var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject(data, responseType);
                }
            }
        }

        public async Task<T> GetAsync<T>(string host, string url, CancellationToken cancellationToken)
        {
            var response = await GetAsync(host, url, typeof (T), cancellationToken);
            return (T) response;
        }

        private HttpClient CreateHttpClient(string host)
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(host)};
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);
            return httpClient;
        }
    }
}