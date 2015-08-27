using System;
using System.Collections.Generic;
using GiTracker.Models;
using GiTracker.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private DelegateCommand<SlideMenuItem> _slideMenuItemTapped;

        public MainPageViewModel(IUnityContainer container)
        {
            Container = container;
            PresentedViewModelType = typeof (IssueList);
        }

        public Type PresentedViewModelType { get; private set; }

        public IUnityContainer Container { get; private set; }

        public IEnumerable<SlideMenuItem> SlideMenu { get; } = new List<SlideMenuItem>
        {
            new SlideMenuItem {Title = "Repositories", ScreenView = typeof (IssueList)},
            new SlideMenuItem {Title = "About", ScreenView = typeof (IssueList)}
        };

        public DelegateCommand<SlideMenuItem> SlideMenuItemTapped => _slideMenuItemTapped ??
                                                                     (_slideMenuItemTapped =
                                                                         new DelegateCommand<SlideMenuItem>(
                                                                             DoSlideMenuItemTapped));

        public event EventHandler PresentedViewModelTypeChanged;

        private void DoSlideMenuItemTapped(SlideMenuItem item)
        {
            PresentedViewModelType = item.ScreenView;
            PresentedViewModelTypeChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}