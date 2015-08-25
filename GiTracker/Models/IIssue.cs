using System;
using System.Collections.Generic;

namespace GiTracker.Models
{
    public interface IIssue
    {
        int Id { get; }
        int Number { get; }
        string Url { get; }
        string WebPage { get; }
        string Title { get; }
        string Body { get; }
        IssueStatus Status { get; }
        IEnumerable<ILabel> Labels { get; }
        IUser Author { get; }
        IUser Assignee { get; }
        IUser ClosedBy { get; }
        DateTime? CreatedAt { get; }
        DateTime? UpdatedAt { get; }
        DateTime? ClosedAt { get; }
        int CommentsCount { get; }
    }
}
