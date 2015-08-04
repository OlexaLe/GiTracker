using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.Api
{
    public interface IGitApiService
    {
        Task<IEnumerable<IIssue>> GetIssuesAsync(CancellationToken cancellationToken);
    }
}
