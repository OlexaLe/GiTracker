using System;
using System.Collections.Generic;

namespace GiTracker.Services.Rest
{
    public class RestRequest
    {
        public Type ReturnValueType { get; set; }
        public string Host { get; set; }
        public string RelativeUrl { get; set; }
        public Dictionary<string, string> DefaultHeaders { get; set; }
        public Dictionary<string, string> UrlParameters { get; set; }
    }
}