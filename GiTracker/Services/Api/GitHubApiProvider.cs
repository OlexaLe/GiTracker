namespace GiTracker.Services.ServiceProvider
{
    class GitHubApiProvider : IGitApiProvider
    {
        public string Host { get { return "https://api.github.com/"; } }
        // TODO: just an example
        public  string GetIssuesUrl { get { return "repos/XamarinGarage/GiTracker/issues"; } }
    }
}
