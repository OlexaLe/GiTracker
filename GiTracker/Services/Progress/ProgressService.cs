using System;
using Acr.UserDialogs;
using GiTracker.Resources.Strings;

namespace GiTracker.Services.Progress
{
    public class ProgressService : IProgressService
    {
        public void ShowProgress()
        {
            ShowProgress(null);
        }

        public void ShowProgress(Action onCancel)
        {
            UserDialogs.Instance.Loading(Shared.Loading, onCancel);
        }

        public void DismissProgress()
        {
            UserDialogs.Instance.Loading().Hide();
        }
    }
}