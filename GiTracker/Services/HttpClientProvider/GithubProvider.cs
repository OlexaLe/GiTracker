﻿using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;

namespace GiTracker.Services.HttpClientProvider
{
    public class GithubProvider : IGitsProvider
    {
        string _host;

        const string UserAgent = "XamarinGarage";

        #region IGitsProvider implementation

        public HttpClient CreateHttpClient ()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(UserAgent);            
            return httpClient;
        }

        public string Host {
            set {
                _host = value;
            }
        }

        public string RequestURL (string relativeUrl)
        {
            return RequestURL (relativeUrl, new Dictionary<string,string> ());
        }

        public string RequestURL (string relativeUrl, Dictionary<string, string> parameters)
        {
            var queryString = BuildParametersString (parameters);
            return string.Format ("{0}{1}?{2}", _host, relativeUrl, queryString);
        }

        public StringContent Content (object parameters)
        {
            var content = Newtonsoft.Json.JsonConvert.SerializeObject (parameters);
            return new StringContent (content, Encoding.UTF8, "application/json");
        }
        #endregion

        string BuildParametersString (Dictionary<string, string> parameters)
        {
            var queryString = new StringBuilder ();

            foreach (KeyValuePair<string, string> parameter in parameters) {
                if (queryString.Length > 0)
                    queryString.Append ('&');
                queryString.AppendFormat ("{0}={1}", parameter.Key, parameter.Value);
            }

            return queryString.ToString ();
        }
    }
}
