using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.Rest
{
    public interface IRestService
    {
        Task<object> GetAsync(string host, string url, Dictionary<string, string> parameters,
            Type responseType, CancellationToken cancellationToken);

        Task<T> GetAsync<T>(string host, string url, Dictionary<string, string> parameters,
            CancellationToken cancellationToken);
    }
}