using System.Threading.Tasks;
using GiTracker.Models;

namespace GiTracker.Services.Login
{
    internal interface ILoginService
    {
        Task<IUser> LoginAsync(string username, string password);
    }
}