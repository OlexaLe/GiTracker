using System;
using System.Collections.Generic;

namespace GiTracker.Services.Rest
{
    public interface IRestRequest
    {
        Type ReturnValueType { get; }
        Type ErrorType { get; }
        string Host { get; }
        string RelativeUrl { get; }
        Dictionary<string, string> DefaultHeaders { get; }
        Dictionary<string, string> UrlParameters { get; }
    }
}