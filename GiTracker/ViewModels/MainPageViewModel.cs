using System;
using System.Collections.Generic;
using GiTracker.Models;
using GiTracker.Models.Events;
using GiTracker.Views;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly IEventAggregator _eventAggregator;
        private DelegateCommand<SlideMenuItem> _slideMenuItemTapped;

        public MainPageViewModel(IUnityContainer container, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Container = container;
            PresentedViewModelType = typeof (RepoListPage);
        }

        public Type PresentedViewModelType { get; private set; }
        public IUnityContainer Container { get; private set; }

        public IEnumerable<SlideMenuItem> SlideMenu { get; } = new List<SlideMenuItem>
        {
            new SlideMenuItem {Title = Resources.Strings.SlideMenu.Repositories, ScreenView = typeof (RepoListPage)},
            new SlideMenuItem {Title = Resources.Strings.SlideMenu.About, ScreenView = typeof (AboutPage)},
            new SlideMenuItem {Title = Resources.Strings.SlideMenu.Logout}
        };

        public DelegateCommand<SlideMenuItem> SlideMenuItemTapped => _slideMenuItemTapped ??
                                                                     (_slideMenuItemTapped =
                                                                         new DelegateCommand<SlideMenuItem>(
                                                                             DoSlideMenuItemTapped));

        public event EventHandler PresentedViewModelTypeChanged;

        private void DoSlideMenuItemTapped(SlideMenuItem item)
        {
            if (item.ScreenView == null)
            {
                _eventAggregator.GetEvent<LogoutEvent>().Publish(null);
            }
            else
            {
                PresentedViewModelType = item.ScreenView;
                PresentedViewModelTypeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}