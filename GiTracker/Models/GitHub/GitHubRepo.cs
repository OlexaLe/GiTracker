using Newtonsoft.Json;

namespace GiTracker.Models.GitHub
{
    internal class GitHubRepo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string Path { get; set; }
    }
}