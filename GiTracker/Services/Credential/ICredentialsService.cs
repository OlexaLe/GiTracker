using System.Collections.Generic;

namespace GiTracker.Services.Credential
{
    public interface ICredentialsService
    {
        string BasicAuthenticationToken { get; }
        bool HasCredentials { get; }
        void SetCredentials(string username, string password);
    }
}