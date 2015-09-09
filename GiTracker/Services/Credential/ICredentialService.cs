using System.Collections.Generic;

namespace GiTracker.Services.Credential
{
    internal interface ICredentialService
    {
        void SetBasicCredential(string username, string password);
        Dictionary<string, string> Credential();
    }
}