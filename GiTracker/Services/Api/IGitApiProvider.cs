namespace GiTracker.Services.ServiceProvider
{
    public interface IGitApiProvider
    {
        string Host { get; }

        string GetIssuesUrl { get; }
    }
}
