using System;
using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.Rest
{
    public interface IRestService
    {
        Task<object> GetAsync(string host, string url, Type responseType, CancellationToken cancellationToken);
        Task<T> GetAsync<T>(string host, string url, CancellationToken cancellationToken);
    }
}