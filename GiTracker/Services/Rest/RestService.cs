using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GiTracker.Services.Rest
{
    class RestService : IRestService
    {
        const string UserAgent = "XamarinGarage";

        HttpClient CreateHttpClient(string host)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(host) };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);            
            return httpClient;
        }

        public async Task<T> GetAsync<T>(string host, string url, CancellationToken cancellationToken)
        {
            using (var client = CreateHttpClient(host))
            {
                using (var response = await client.GetAsync(url, cancellationToken).ConfigureAwait(false))
				{
					cancellationToken.ThrowIfCancellationRequested();

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        return JsonConvert.DeserializeObject<T>(data);
                    }
                    else
                        throw new Exception(response.ToString());
				}                
            }
        }
    }
}
