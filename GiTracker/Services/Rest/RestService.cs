using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GiTracker.Services.HttpClientProvider;

namespace GiTracker.Services.Rest
{
    class RestService : IRestService
    {
        const string UserAgent = "XamarinGarage";

        protected readonly IGitsProvider _gitProvider;

        protected RestService(IGitsProvider gitProvider)
        {
            _gitProvider = gitProvider;
        }

        public async Task<T> GetAsync<T>(string host, string url, CancellationToken cancellationToken)
        {
            using (var client = _gitProvider.CreateHttpClient())
            {
                using (var response = await client.GetAsync(_gitProvider.RequestURL(url), 
                    cancellationToken).ConfigureAwait(false))
				{
					cancellationToken.ThrowIfCancellationRequested();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(response.ToString());
                    
                    var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(data);
                }                
            }
        }
    }
}
