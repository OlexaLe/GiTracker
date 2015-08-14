namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        string Host { get; }

        string GetIssuesUrl { get; }
    }
}
