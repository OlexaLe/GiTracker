using System;

namespace GiTracker.Services.Api
{
    public interface IGitApiProvider
    {
        string Host { get; }
        Type IssueType { get; }
        Type IssueListType { get; }
        Type UserType { get; }
        Type ReposListType { get; }
        string ReposUrl { get; }
        string GetIssuesUrl(string repository);
    }
}