using System.Collections.Generic;

namespace GiTracker.Services.Credential
{
    public interface ICredentialService
    {
        void SetBasicCredential(string username, string password);
        Dictionary<string, string> Credential();
        bool HasCredential();
    }
}