using System;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Services.Dialogs;

namespace GiTracker.Helpers
{
    public class Loader
    {
        private readonly IDialogService _dialogService;
        private bool _isLoading;
        private CancellationTokenSource _loadingCTS;

        public Loader(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            private set
            {
                if (_isLoading == value) return;

                _isLoading = value;
                LoadinChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler LoadinChanged;

        public async Task LoadAsync(Func<CancellationToken, Task> taskFactory)
        {
            CancelLoading();

            IsLoading = true;

            try
            {
                await taskFactory(_loadingCTS.Token);
            }
            catch (Exception e)
            {
                await _dialogService.ShowMessageAsync(e.Message);
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void CancelLoading()
        {
            _loadingCTS?.Cancel();
            _loadingCTS = new CancellationTokenSource();
        }
    }
}