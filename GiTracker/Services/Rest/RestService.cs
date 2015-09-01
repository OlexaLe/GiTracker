using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GiTracker.Services.HttpClientProvider;

namespace GiTracker.Services.Rest
{
    internal class RestService : IRestService
    {
        protected readonly IHttpClientProvider HttpClientProvider;

        protected RestService(IHttpClientProvider httpClientProvider)
        {
            HttpClientProvider = httpClientProvider;
        }

        public async Task<object> GetAsync(string host, string url, Type responseType, CancellationToken cancellationToken)
        {
            using (var client = HttpClientProvider.CreateHttpClient())
            {
                using (var response = await client.GetAsync(HttpClientProvider.GetRequestUrl(host, url),
                    cancellationToken).ConfigureAwait(false))
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
            var response = await GetAsync(host, url, typeof(T), cancellationToken);
            return (T)response;
        }
    }
}