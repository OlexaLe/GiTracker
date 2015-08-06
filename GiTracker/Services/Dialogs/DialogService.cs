using GiTracker.Resources.Strings;
using System.Threading.Tasks;

namespace GiTracker.Services.Dialogs
{
	class DialogService : IDialogService
	{
		public Task ShowMessageAsync(string title = "", string content = "")
		{
			return App.Instance.MainPage.DisplayAlert(title, content, Shared.Ok);
		}
	}
}
