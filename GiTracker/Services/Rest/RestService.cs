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
        HttpClient CreateHttpClient(string host, string userAgent)
        {
            var httpClient = new HttpClient { BaseAddress = new Uri(host) };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (!string.IsNullOrEmpty(userAgent))
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);            
            return httpClient;
        }

        public async Task<T> GetAsync<T>(RequestSettings settings, CancellationToken cancellationToken)
        {
            using (var client = CreateHttpClient(settings.HostName, settings.UserAgent))
            {
                using (var response = await client.GetAsync(settings.Url, cancellationToken).ConfigureAwait(false))
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
