using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Login
{
    internal class LoginService : ILoginService
    {
        private readonly IGitApiProvider _gitApiProvider;
        private readonly IRestService _restService;

        public LoginService(IRestService restService, IGitApiProvider gitApiProvider)
        {
            _restService = restService;
            _gitApiProvider = gitApiProvider;
        }

        public async Task<IUser> LoginAsync(string username, string password)
        {
            var user =
                await
                    _restService.GetAsync(_gitApiProvider.GetLoginRequest(username, password), CancellationToken.None)
                        .ConfigureAwait(false);

            return user as IUser;
        }
    }
}