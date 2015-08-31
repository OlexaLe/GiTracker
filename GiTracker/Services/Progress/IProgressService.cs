using System;

namespace GiTracker.Services.Progress
{
    public interface IProgressService
    {
        void ShowProgress();
        void ShowProgress(Action onCancel);
        void DismissProgress();
    }
}