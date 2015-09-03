using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.Repos
{
    public interface IRepoService
    {
        Task<IRepo> GetReposAsync(CancellationToken cancellationToken);
    }
}