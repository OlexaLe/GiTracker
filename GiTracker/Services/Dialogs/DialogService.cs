using System.Threading.Tasks;
using GiTracker.Resources.Strings;

namespace GiTracker.Services.Dialogs
{
	class DialogService : IDialogService
	{
		public Task ShowOkMessageAsync(string title = "", string content = "")
		{
			return App.Instance.MainPage.DisplayAlert(title, content, Shared.Ok);
		}

		public async void ShowOkMessage(string title = "", string content = "")
		{
			try { await ShowOkMessageAsync(title, content); }
			catch { }
		}
	}
}
