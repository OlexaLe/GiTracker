using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Repos
{
    internal class RepoService : IRepoService
    {
        private readonly IGitApiProvider _gitApiProvider;
        private readonly IRestService _restService;

        public RepoService(IRestService restService,
            IGitApiProvider gitApiProvider)
        {
            _restService = restService;
            _gitApiProvider = gitApiProvider;
        }

        public async Task<IEnumerable<IRepo>> GetReposAsync(CancellationToken cancellationToken)
        {
            var repos =
                await
                    _restService.GetAsync(_gitApiProvider.Host, _gitApiProvider.ReposUrl,
                        _gitApiProvider.ReposListType, cancellationToken)
                        .ConfigureAwait(false);

            return repos as IEnumerable<IRepo>;
        }
    }
}