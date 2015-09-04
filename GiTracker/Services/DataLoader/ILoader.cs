using System;
using System.Threading;
using System.Threading.Tasks;

namespace GiTracker.Services.DataLoader
{
    public interface ILoader
    {
        bool IsLoading { get; }
        event EventHandler LoadingChanged;
        Task LoadAsync(Func<CancellationToken, Task> taskFactory);
        void CancelLoading();
    }
}