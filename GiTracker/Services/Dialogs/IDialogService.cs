using System.Threading.Tasks;

namespace GiTracker.Services.Dialogs
{
	public interface IDialogService
	{
		Task ShowOkMessageAsync(string title = "", string content = "");
		void ShowOkMessage(string title = "", string content = "");
	}
}
