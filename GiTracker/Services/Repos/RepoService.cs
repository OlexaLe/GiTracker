using System;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.Repos
{
    internal class RepoService : IRepoService
    {
        public Task<IRepo> GetReposAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}