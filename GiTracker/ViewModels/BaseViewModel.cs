using System;
using GiTracker.Helpers;
using Prism.Mvvm;

namespace GiTracker.ViewModels
{
    public abstract class BaseViewModel : BindableBase
    {
        protected Loader _loader = new Loader();

        string _title;
        public string Title
        {
            get { return _title; }
            protected set { SetProperty(ref _title, value); }
        }
    }
}
