using System;
using System.Collections.Generic;
using System.Text;

namespace GiTracker.Services.Credential
{
    internal class CredentialService : ICredentialService
    {
        private string _basicAuthentication;

        public Dictionary<string, string> Credential()
        {
            return new Dictionary<string, string> {{"Authorization", $"Basic {_basicAuthentication}"}};
        }

        public void SetBasicCredential(string username, string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{username}:{password}");
            _basicAuthentication = Convert.ToBase64String(plainTextBytes);
        }
    }
}