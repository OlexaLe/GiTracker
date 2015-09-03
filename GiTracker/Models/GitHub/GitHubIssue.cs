using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GiTracker.Models.GitHub
{
    public class GitHubIssue : IIssue
    {
        [JsonProperty(PropertyName = "labels")]
        public GitHubLabel[] GitHubLabels { get; set; }

        [JsonProperty(PropertyName = "user")]
        public GitHubUser GitHubAuthor { get; set; }

        [JsonProperty(PropertyName = "assignee")]
        public GitHubUser GitHubAssignee { get; set; }

        [JsonProperty(PropertyName = "closed_by")]
        public GitHubUser GitHubClosedBy { get; set; }

        [JsonProperty(PropertyName = "pull_request")]
        public object PullRequest { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "html_url")]
        public string WebPage { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        [JsonProperty(PropertyName = "state"),
         JsonConverter(typeof (StringEnumConverter))]
        public IssueStatus Status { get; set; }

        [JsonIgnore]
        public IEnumerable<ILabel> Labels => GitHubLabels;

        [JsonIgnore]
        public IUser Author => GitHubAuthor;

        [JsonIgnore]
        public IUser Assignee => GitHubAssignee;

        [JsonIgnore]
        public IUser ClosedBy => GitHubClosedBy;

        [JsonProperty(PropertyName = "created_at"),
         JsonConverter(typeof (IsoDateTimeConverter))]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "updated_at"),
         JsonConverter(typeof (IsoDateTimeConverter))]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "closed_at"),
         JsonConverter(typeof (IsoDateTimeConverter))]
        public DateTime? ClosedAt { get; set; }

        [JsonProperty(PropertyName = "comments")]
        public int CommentsCount { get; set; }

        public bool IsPullRequest => PullRequest != null;
    }
}