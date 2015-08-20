using System;
using System.Collections.Generic;
using System.Linq;
using GiTracker.Models;

namespace GiTracker.ViewModels
{
    public class IssueViewModel
    {
        readonly IIssue _issue;

        public IssueViewModel(IIssue issue)
        {
            _issue = issue;
        }

        public int? Number => _issue?.Number;
        public string Title => _issue?.Title;
        public string Body => _issue?.Body;
        public bool HasBody => !string.IsNullOrEmpty(Body);
        public string WebPage => _issue.WebPage;
        public string Url => _issue?.Url;
        public IssueStatus? Status => _issue?.Status;
        public IEnumerable<ILabel> Labels => _issue?.Labels;
        public bool? HasLabels => Labels?.Any();
        public IUser Author => _issue?.Author;
        public IUser Assignee => _issue?.Assignee;
        public bool HasAssignee => Assignee != null;
        public DateTime? CreatedAt => _issue?.CreatedAt?.ToLocalTime();
        public DateTime? UpdatedAt => _issue?.UpdatedAt?.ToLocalTime();
        public DateTime? ClosedAt => _issue?.ClosedAt?.ToLocalTime();
    }
}
