using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.Rest
{
    public interface IRestService
    {
        Task<object> GetAsync(RestRequest request, CancellationToken cancellationToken);
    }
}