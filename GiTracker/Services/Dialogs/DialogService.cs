using GiTracker.Resources.Strings;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GiTracker.Services.Dialogs
{
	class DialogService : IDialogService
	{
		public Task ShowMessageAsync(string title = "", string content = "")
		{
			return Application.Current.MainPage.DisplayAlert(title, content, Shared.Ok);
		}
	}
}
