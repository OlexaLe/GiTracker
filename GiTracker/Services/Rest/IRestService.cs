using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.Rest
{
    public interface IRestService
    {
        Task<object> GetAsync(IRestRequest request, CancellationToken cancellationToken);
        Task<object> PostAsync(IRestRequest request, object requestBody, CancellationToken cancellationToken);
    }
}