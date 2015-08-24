using System;

namespace GiTracker.Models
{
    public interface IComment
    {
        int Id { get; }
        IUser Author { get; }
        string Url { get; }
        string Body { get; }
        string WebPage { get; }
        string IssueApiUrl { get; }
        DateTime? CreatedAt { get; }
        DateTime? UpdatedAt { get; }
    }
}