using GiTracker.ViewModels;
using Xamarin.Forms;

namespace GiTracker.Views
{
    public abstract class BasePage : ContentPage
    {
        public BasePage()
        {
            SetBinding(Page.TitleProperty, new Binding { Path = nameof(BaseViewModel.Title) });
        }
    }
}
