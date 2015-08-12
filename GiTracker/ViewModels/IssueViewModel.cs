using System;
using System.Collections.Generic;
using GiTracker.Helpers;
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

        public string Number => _issue?.Number.ToString();
        public string Url => _issue?.Url;
        public string Title => _issue?.Title;
        public string Body => _issue?.Body;
        public string Status => _issue?.Status.GetDisplayName();
        public IEnumerable<ILabel> Labels => _issue?.Labels;
        public IUser Author => _issue?.Author;
        public IUser Assignee => _issue?.Assignee;
        public DateTime? CreatedAt => _issue?.CreatedAt?.ToLocalTime();
        public DateTime? UpdatedAt => _issue?.UpdatedAt?.ToLocalTime();
        public DateTime? ClosedAt => _issue?.ClosedAt?.ToLocalTime();
    }
}