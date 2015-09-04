using System;
using System.Threading;
using System.Threading.Tasks;
using GiTracker.Services.Dialogs;

namespace GiTracker.Services.DataLoader
{
    public class Loader : ILoader
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
                LoadingChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler LoadingChanged;

        public async Task LoadAsync(Func<CancellationToken, Task> taskFactory)
        {
            CancelLoading();

            IsLoading = true;

            try
            {
                await taskFactory(_loadingCTS.Token);
            }
            catch (OperationCanceledException)
            {
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