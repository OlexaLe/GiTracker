using System;

namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        string Host { get; }
        string GetIssuesUrl { get; }
        string GetOpenIssuesUrl { get; }
        string GetClosedIssuesUrl { get; }
        Type IssueType { get; }
        Type IssueListType { get; }
        Type UserType { get; }
    }
}