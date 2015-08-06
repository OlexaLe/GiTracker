using GiTracker.Helpers;
using Prism.Mvvm;
using Prism.Navigation;

namespace GiTracker.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
		public Loader Loader { get; private set; }
		
		public BaseViewModel(Loader loader)
		{
			Loader = loader;
		}

        string _title;
        public string Title
        {
            get { return _title; }
            protected set { SetProperty(ref _title, value); }
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {

        }
    }
}
