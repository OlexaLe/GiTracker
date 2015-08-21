using System;

namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        string Host { get; }
        string GetIssuesUrl { get; }
        Type IssueType { get; }
        Type IssueListType { get; }
        Type UserType { get; }
    }
}