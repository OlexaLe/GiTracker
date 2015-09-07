using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        RestRequest GetIssuesRequest(string repository);
        RestRequest GetUserRepositoriesRequest();
        RestRequest CreateCommentRequest(string repository, int issueId);
    }
}