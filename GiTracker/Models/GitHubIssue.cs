using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GiTracker.Models
{
    public class GitHubIssue : IIssue
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "state"),
        JsonConverter(typeof(StringEnumConverter))]
        public IssueStatus Status { get; set; }

        [JsonProperty(PropertyName = "labels")]
        public GitHubLabel[] GitHubLabels { get; set; }

        [JsonIgnore]
        public IEnumerable<ILabel> Labels => GitHubLabels;

        [JsonProperty(PropertyName = "user")]
        public GitHubUser GitHubAuthor { get; set; }

        [JsonIgnore]
        public IUser Author => GitHubAuthor;

        [JsonProperty(PropertyName = "assignee")]
        public GitHubUser GitHubAssignee { get; set; }

        [JsonIgnore]
        public IUser Assignee => GitHubAssignee;

        [JsonProperty(PropertyName = "created_at"),
        JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? GitHubCreatedAt { get; set; }
        
        [JsonIgnore]
        public DateTime? CreatedAt => GitHubCreatedAt;

        [JsonProperty(PropertyName = "updated_at"),
        JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? GitHubUpdatedAt { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedAt => GitHubUpdatedAt;

        [JsonProperty(PropertyName = "closed_at"),
        JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? GitHubClosedAt { get; set; }

        [JsonIgnore]
        public DateTime? ClosedAt => GitHubClosedAt;
    }
}
