using System.Threading.Tasks;

namespace IYFRaipur.Services
{
    public interface IAuthService
    {
        void SignOut();

        bool IsSignIn();
        Task<bool> SendOtpCodeAsync(string phoneNumber);
        Task<bool> VerifyOtpCodeAsync(string code);

    }
}
