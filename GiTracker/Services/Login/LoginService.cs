using System.Threading;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Api;
using GiTracker.Services.Credential;
using GiTracker.Services.Rest;

namespace GiTracker.Services.Login
{
    internal class LoginService : ILoginService
    {
        private readonly ICredentialService _credentialService;
        private readonly IGitApiProvider _gitApiProvider;
        private readonly IRestService _restService;

        public LoginService(IRestService restService, IGitApiProvider gitApiProvider,
            ICredentialService credentialService)
        {
            _restService = restService;
            _gitApiProvider = gitApiProvider;
            _credentialService = credentialService;
        }

        public async Task<IUser> LoginAsync(string username, string password)
        {
            _credentialService.SetBasicCredential(username, password);
            var user =
                await
                    _restService.GetAsync(_gitApiProvider.GetUserRequest(), CancellationToken.None)
                        .ConfigureAwait(false);

            return user as IUser;
        }
    }
}