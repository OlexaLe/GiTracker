using GiTracker.Services.Rest;

namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        RestRequest GetIssuesRequest(string repository);
    }
}