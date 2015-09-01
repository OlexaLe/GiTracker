using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GiTracker.Services.HttpClientProvider;

namespace GiTracker.Services.Rest
{
    internal class RestService : IRestService
    {
        protected readonly IGitsProvider _gitProvider;

        protected RestService(IGitsProvider gitProvider)
        {
            _gitProvider = gitProvider;
        }

        public async Task<object> GetAsync(string host, string url, Type responseType, CancellationToken cancellationToken)
        {
            using (var client = _gitProvider.CreateHttpClient())
            {
                using (var response = await client.GetAsync(_gitProvider.RequestUrl(url), 
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
            var response = await GetAsync(host, url, typeof (T), cancellationToken);
            return (T) response;
        }
    }
}
