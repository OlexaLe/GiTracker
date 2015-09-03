using System;
using System.Collections.Generic;
using System.Net;
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
                                GetRequestUrl(request.Host, request.RelativeUrl, request.UrlParameters),
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

        private string GetRequestUrl(string host, string relativeUrl, Dictionary<string, string> parameters)
        {
            var queryString = BuildParametersString(parameters);
            return $"{host}{relativeUrl}?{queryString}";
        }

        private string BuildParametersString(Dictionary<string, string> parameters)
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