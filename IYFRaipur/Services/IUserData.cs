using IYFRaipur.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace IYFRaipur.Services
{
    public interface IUserData
    {
        void Save(string name, string email,string image);
        void Save(string accountType);
        string GetPhone();
        Task<User> GetUserAsync();
    }
}
