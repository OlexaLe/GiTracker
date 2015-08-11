namespace GiTracker.Services.Api
{
    class GitHubApiProvider : IGitApiProvider
    {
        public string Host => "https://api.github.com/";
        // TODO: just an example
        public  string GetIssuesUrl => "repos/XamarinGarage/GiTracker/issues";
    }
}
