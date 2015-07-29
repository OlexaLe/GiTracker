using System;
using Prism.Mvvm;

namespace GiTracker.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        string _title = "Main Page";

        public string Title {
            get { return _title; }
            set { SetProperty (ref _title, value); }
        }
    }
}
