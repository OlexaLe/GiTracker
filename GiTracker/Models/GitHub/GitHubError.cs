using Newtonsoft.Json;

namespace GiTracker.Models.GitHub
{
    public class GitHubError : IGitError
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}