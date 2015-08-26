using System;
using GiTracker.Views;
using Microsoft.Practices.Unity;
using Prism.Mvvm;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        //private DelegateCommand _openIssueListCommand;

        public MainPageViewModel(IUnityContainer container)
        {
            Container = container;
            PresentedViewModelType = typeof (IssueList);
        }

        public Type PresentedViewModelType { get; private set; }

        public IUnityContainer Container { get; private set; }

        //private void OpenIssueList()

        //public DelegateCommand OpenIssueListCommand =>

        //    _openIssueListCommand ?? (_openIssueListCommand = new DelegateCommand(OpenIssueList));
        //{
        //    NavigationService.Navigate<IssueListViewModel>(null, false);
        //}
    }
}