using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GiTracker.Models
{
    internal class GitHubComment : IComment
    {
        [JsonProperty(PropertyName = "user")]
        public GitHubUser GitHubAuthor { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonIgnore]
        public IUser Author => GitHubAuthor;

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "html_url")]
        public string WebPage { get; set; }

        [JsonProperty(PropertyName = "issue_url")]
        public string IssueApiUrl { get; set; }

        [JsonProperty(PropertyName = "created_at"),
         JsonConverter(typeof (IsoDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at"),
         JsonConverter(typeof (IsoDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }
    }
}