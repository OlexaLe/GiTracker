using GiTracker.ViewModels;
using Microsoft.Practices.Unity;
using Xamarin.Forms;

namespace GiTracker.Views
{
    public partial class MainPage : MasterDetailPage
    {
        private readonly MainPageViewModel _viewModel;
        private bool _isInitialized;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = (MainPageViewModel) BindingContext;

            //var view = ServiceLocator.Current.GetInstance<object>(_viewModel.PresentedViewModelType.ToString()) as Page;

            var page = _viewModel.Container.Resolve(_viewModel.PresentedViewModelType) as Page;
            Detail = new NavigationPage(page);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (!_isInitialized)
            {
                _isInitialized = true;
                ((Detail as NavigationPage)?.CurrentPage.BindingContext as BaseViewModel)?.OnNavigatedTo(null);
            }
        }
    }
}