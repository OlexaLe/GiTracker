using Newtonsoft.Json;

namespace GiTracker.Models.GitHub
{
    public class GitHubUser : IUser
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "login")]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "avatar_url")]
        public string AvatarUrl { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}