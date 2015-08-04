using System;
using Prism.Mvvm;

namespace GiTracker.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {
        string _title;
        public string Title
        {
            get { return _title; }
            protected set { SetProperty(ref _title, value); }
        }
    }
}
