using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        RestRequest GetLoginRequest(string username, string password);
        RestRequest GetIssuesRequest(string repository);
        RestRequest GetUserRepositoriesRequest();
        RestRequest GetCreateCommentRequest(string repository, int issueId);
        RestRequest GetLoadCommentsRequest(string repository, int issueId);
    }
}