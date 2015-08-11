using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.Rest
{
    public interface IRestService
    {
        Task<T> GetAsync<T>(string host, string url, CancellationToken cancellationToken);
    }
}
