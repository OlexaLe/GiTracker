using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GiTracker.Services.Rest
{
    internal class RestService : IRestService
    {
        public async Task<object> GetAsync(RestRequest request, CancellationToken cancellationToken)
        {
            using (var client = CreateHttpClient(request.DefaultHeaders))
            {
                using (
                    var response =
                        await
                            client.GetAsync(
                                await GetRequestUrl(request.Host, request.RelativeUrl, request.UrlParameters),
                                cancellationToken).ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(response.ToString());

                    var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject(data, request.ReturnValueType);
                }
            }
        }

        public async Task<object> PostAsync(RestRequest request, object requestBody, CancellationToken cancellationToken)
        {
            using (var client = CreateHttpClient(request.DefaultHeaders))
            {
                var jsonString = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                using (
                    var response =
                        await
                            client.PostAsync(
                                await GetRequestUrl(request.Host, request.RelativeUrl, request.UrlParameters),
                                content,
                                cancellationToken).ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (!response.IsSuccessStatusCode)
                        throw new Exception(response.ToString());

                    var data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject(data, request.ReturnValueType);
                }
            }
        }

        private HttpClient CreateHttpClient(Dictionary<string, string> headerParams)
        {
            var httpClient = new HttpClient();
            foreach (var headerParam in headerParams)
                httpClient.DefaultRequestHeaders.Add(headerParam.Key, headerParam.Value);

            return httpClient;
        }

        private async Task<string> GetRequestUrl(string host, string relativeUrl, Dictionary<string, string> parameters)
        {
            var queryString = parameters != null ? $"?{await BuildParametersString(parameters)}" : string.Empty;
            return $"{host}{relativeUrl}{queryString}";
        }

        private Task<string> BuildParametersString(Dictionary<string, string> parameters)
        {
            var content = new FormUrlEncodedContent(parameters);
            return content.ReadAsStringAsync();
        }
    }
}