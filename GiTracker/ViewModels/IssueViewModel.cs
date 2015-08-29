using System;
using System.Collections.Generic;
using System.Linq;
using GiTracker.Models;

namespace GiTracker.ViewModels
{
    public class IssueViewModel
    {
        private readonly IIssue _issue;

        public IssueViewModel(IIssue issue)
        {
            _issue = issue;
        }

        public int? Number => _issue?.Number;
        public string Title => _issue?.Title;
        public string Body => _issue?.Body;
        public string WebPage => _issue.WebPage;
        public string Url => _issue?.Url;

        public IssueStatus? Status
            =>
                (_issue?.IsPullRequest).GetValueOrDefault()
                    ? (_issue?.Status == IssueStatus.Open ? IssueStatus.OpenPullRequest : IssueStatus.ClosedPullRequest)
                    : (_issue?.Status);

        public IEnumerable<ILabel> Labels => _issue?.Labels;
        public bool? HasLabels => _issue?.Labels != null && _issue.Labels.Any();
        public IUser Author => _issue?.Author;
        public IUser Assignee => _issue?.Assignee;
        public IUser ClosedBy => _issue?.ClosedBy;
        public DateTime? CreatedAt => _issue?.CreatedAt?.ToLocalTime();
        public DateTime? UpdatedAt => _issue?.UpdatedAt?.ToLocalTime();
        public DateTime? ClosedAt => _issue?.ClosedAt?.ToLocalTime();
        public bool HasComments => _issue?.CommentsCount > 0;
        public bool IsOpened => _issue?.Status == IssueStatus.Open;
        public bool IsClosed => _issue?.Status == IssueStatus.Closed;
    }
}