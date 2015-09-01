using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Services.HttpClientProvider;
using Newtonsoft.Json;

namespace GiTracker.Services.Rest
{
    internal class RestService : IRestService
    {
        protected readonly IHttpClientProvider HttpClientProvider;

        public RestService(IHttpClientProvider httpClientProvider)
        {
            HttpClientProvider = httpClientProvider;
        }

        public async Task<object> GetAsync(string host, string url,
            Dictionary<string, string> parameters, Type responseType,
            CancellationToken cancellationToken)
        {
            using (var client = HttpClientProvider.CreateHttpClient())
            {
                using (var response = await client.GetAsync(HttpClientProvider.GetRequestUrl(host, url, parameters),
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

        public async Task<T> GetAsync<T>(string host, string url,
            Dictionary<string, string> parameters, CancellationToken cancellationToken)
        {
            var response = await GetAsync(host, url, parameters, typeof (T), cancellationToken);
            return (T) response;
        }
    }
}