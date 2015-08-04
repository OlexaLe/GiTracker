using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GiTracker.Models;
using GiTracker.Services.Api;
using Prism.Commands;

namespace GiTracker.ViewModels
{
    public class IssueListViewModel : BaseViewModel
    {
        readonly IGitApiService _gitApiService;

        public IssueListViewModel(IGitApiServiceFactory gitApiServiceFactory)
        {
            _gitApiService = gitApiServiceFactory.GetApiService();
        }

        ObservableCollection<IIssue> _issues;
        public ObservableCollection<IIssue> Issues
        {
            get { return _issues; }
            private set { SetProperty(ref _issues, value); }
        }

        Task LoadIssuesAsync()
        {
            return _loader.LoadAsync(async (cancellationToken) =>
            {
                var issues = await _gitApiService.GetIssuesAsync(cancellationToken);
                Issues = new ObservableCollection<IIssue>(issues);
            });
        }

        DelegateCommand _updateIssuesCommand;
        public DelegateCommand UpdateIssuesCommand
        {
            get { return _updateIssuesCommand ?? (_updateIssuesCommand = new DelegateCommand(UpdateIssues)); }
        }

        async void UpdateIssues()
        {
            await LoadIssuesAsync();
        }
    }
}
