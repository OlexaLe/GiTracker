namespace GiTracker.Services.Credential
{
    public interface ICredentialsService
    {
        string BasicAuthenticationToken { get; }
        bool HasCredentials { get; }
        void SetCredentials(string username, string password);
        void RemoveCredentials();
        void StoreCredentials();
    }
}