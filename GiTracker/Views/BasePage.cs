using GiTracker.ViewModels;
using Xamarin.Forms;

namespace GiTracker.Views
{
    public abstract class BasePage : ContentPage
    {
        public BasePage()
        {
            SetBinding(TitleProperty, new Binding {Path = nameof(BaseViewModel.Title)});
        }
    }
}