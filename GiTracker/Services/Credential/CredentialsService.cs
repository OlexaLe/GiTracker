using System;
using System.Text;
using GiTracker.Services.Settings;

namespace GiTracker.Services.Credential
{
    internal class CredentialsService : ICredentialsService
    {
        private const string SessionSettingsKey = "SessionSettingsKey";
        private readonly ISettingsManager _settingsManager;

        private string _basicAuthenticationToken;

        public CredentialsService(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }

        public void SetCredentials(string username, string password)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes($"{username}:{password}");
            _basicAuthenticationToken = Convert.ToBase64String(plainTextBytes);
        }

        public void RemoveCredentials()
        {
            _settingsManager.RemoveSetting(SessionSettingsKey);
            _basicAuthenticationToken = string.Empty;
        }

        public void StoreCredentials()
        {
            _settingsManager.AddSetting(SessionSettingsKey, _basicAuthenticationToken);
        }

        public bool HasCredentials => !string.IsNullOrEmpty(BasicAuthenticationToken);

        public string BasicAuthenticationToken
            =>
                _basicAuthenticationToken ??
                (_basicAuthenticationToken = _settingsManager.ReadSetting(SessionSettingsKey) as string);
    }
}