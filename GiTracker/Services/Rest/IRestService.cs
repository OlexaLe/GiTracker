using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.Rest
{
    public interface IRestService
    {
        Task<T> GetAsync<T>(RequestSettings settings, CancellationToken cancellationToken);
    }
}
