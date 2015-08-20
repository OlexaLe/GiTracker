using System.Threading.Tasks;

namespace GiTracker.Services.Login
{
    interface ILoginService
    {
        Task LoginAsync(string username, string password);
    }
}