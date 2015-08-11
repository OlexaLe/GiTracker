using System;
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
        public GitHubLabel[] _labels { get; set; }

        [JsonIgnore]
        public ILabel[] Labels => _labels;

        [JsonProperty(PropertyName = "user")]
        public GitHubUser _author { get; set; }

        [JsonIgnore]
        public IUser Author => _author;

        [JsonProperty(PropertyName = "assignee")]
        public GitHubUser _assignee { get; set; }

        [JsonIgnore]
        public IUser Assignee => _assignee;

        [JsonProperty(PropertyName = "created_at"),
        JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? _createdAt { get; set; }
        
        [JsonIgnore]
        public DateTime? CreatedAt => _createdAt?.ToLocalTime();

        [JsonProperty(PropertyName = "updated_at"),
        JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? _updatedAt { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedAt => _updatedAt?.ToLocalTime();

        [JsonProperty(PropertyName = "closed_at"),
        JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? _closedAt { get; set; }

        [JsonIgnore]
        public DateTime? ClosedAt => _closedAt?.ToLocalTime();
    }
}
