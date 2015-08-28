using System;
using GiTracker.ViewModels;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace GiTracker.Views
{
    public partial class MainPage : MasterDetailPage
    {
        private readonly MainPageViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = (MainPageViewModel) BindingContext;
            ChangeDetailPage(_viewModel.PresentedViewModelType);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.PresentedViewModelTypeChanged += OnPresentedViewModelTypeChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _viewModel.PresentedViewModelTypeChanged -= OnPresentedViewModelTypeChanged;
        }

        private void OnPresentedViewModelTypeChanged(object sender, EventArgs eventArgs)
        {
            ChangeDetailPage(_viewModel.PresentedViewModelType);
        }

        private void ChangeDetailPage(Type newPageType)
        {
            var page = _viewModel.Container.Resolve(newPageType) as Page;
            Detail = new NavigationPage(page);
            IsPresented = false;

            (page?.BindingContext as BaseViewModel)?.OnNavigatedTo(null);
        }
    }
}