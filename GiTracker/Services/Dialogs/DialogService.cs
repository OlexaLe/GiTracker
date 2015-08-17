using System.Threading.Tasks;
using GiTracker.Resources.Strings;
using Xamarin.Forms;

namespace GiTracker.Services.Dialogs
{
    internal class DialogService : IDialogService
    {
        public Task ShowMessageAsync(string content)
        {
            return ShowMessageAsync(string.Empty, content);
        }

        public Task ShowMessageAsync(string title, string content)
        {
            return Application.Current.MainPage.DisplayAlert(title, content, Shared.Ok);
        }
    }
}