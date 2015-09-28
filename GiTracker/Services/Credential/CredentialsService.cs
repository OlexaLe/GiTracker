using System;
using System.Collections.Generic;
using System.Text;

namespace GiTracker.Services.Credential
{
    internal class CredentialsService : ICredentialsService
    {
        public Dictionary<string, string> Credentials => new Dictionary<string, string>
        {
            ["Authorization"] = $"Basic {BasicAuthenticationToken}"
        };

        public void SetCredentials(string username, string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{username}:{password}");
            BasicAuthenticationToken = Convert.ToBase64String(plainTextBytes);
        }

        public bool HasCredentials => !string.IsNullOrEmpty(BasicAuthenticationToken);

        public string BasicAuthenticationToken { get; private set; }
    }
}