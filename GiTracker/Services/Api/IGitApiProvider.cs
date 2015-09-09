using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        RestRequest GetLoginRequest(string username, string password);
        RestRequest GetIssuesRequest(string repository);
        RestRequest GetUserRepositoriesRequest();
    }
}