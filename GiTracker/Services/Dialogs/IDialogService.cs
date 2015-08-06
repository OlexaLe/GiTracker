using System.Threading.Tasks;

namespace GiTracker.Services.Dialogs
{
	public interface IDialogService
	{
		Task ShowMessageAsync(string title = "", string content = "");
	}
}
