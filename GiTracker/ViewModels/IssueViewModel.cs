using System;
using System.Collections.Generic;
using System.Linq;
using GiTracker.Models;

namespace GiTracker.ViewModels
{
    public class IssueViewModel
    {
        public IssueViewModel(IIssue issue)
        {
            Issue = issue;
        }

        public IIssue Issue { get; }
        public int? Number => Issue?.Number;
        public string Title => Issue?.Title;
        public string Body => Issue?.Body;
        public string WebPage => Issue.WebPage;
        public string Url => Issue?.Url;

        public IssueStatus? Status
            =>
                (Issue?.IsPullRequest).GetValueOrDefault()
                    ? (Issue?.Status == IssueStatus.Open ? IssueStatus.OpenPullRequest : IssueStatus.ClosedPullRequest)
                    : (Issue?.Status);

        public IEnumerable<ILabel> Labels => Issue?.Labels;
        public bool? HasLabels => Issue?.Labels != null && Issue.Labels.Any();
        public IUser Author => Issue?.Author;
        public IUser Assignee => Issue?.Assignee;
        public IUser ClosedBy => Issue?.ClosedBy;
        public DateTime? CreatedAt => Issue?.CreatedAt?.ToLocalTime();
        public DateTime? UpdatedAt => Issue?.UpdatedAt?.ToLocalTime();
        public DateTime? ClosedAt => Issue?.ClosedAt?.ToLocalTime();
        public bool HasComments => Issue?.CommentsCount > 0;
        public bool IsOpened => Issue?.Status == IssueStatus.Open;
        public bool IsClosed => Issue?.Status == IssueStatus.Closed;
    }
}