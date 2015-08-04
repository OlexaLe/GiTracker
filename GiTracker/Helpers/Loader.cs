using System;
using System.Threading;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace GiTracker.Helpers
{
    public class Loader : BindableBase
    {
        bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            private set { SetProperty(ref _isLoading, value); }
        }

        CancellationTokenSource _loadingCTS;

        public async Task LoadAsync(Func<CancellationToken, Task> taskFactory)
        {
            CancelLoading();

            IsLoading = true;

            try
            { await taskFactory(_loadingCTS.Token); }
            catch (Exception e)
            { throw; }
            finally
            { IsLoading = false; }
        }

        public void CancelLoading()
        {
            if (_loadingCTS != null)
                _loadingCTS.Cancel();

            _loadingCTS = new CancellationTokenSource();
        }
    }
}
