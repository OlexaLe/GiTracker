using System.Threading.Tasks;

namespace GiTracker.Services.Dialogs
{
    public interface IDialogService
    {
        Task ShowMessageAsync(string content);
        Task ShowMessageAsync(string title, string content);
    }
}