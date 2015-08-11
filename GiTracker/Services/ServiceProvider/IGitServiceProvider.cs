using GiTracker.Services.Issues;

namespace GiTracker.Services.ServiceProvider
{
    public interface IGitServiceProvider
    {
        IIssueService GetIssueService();
    }
}
