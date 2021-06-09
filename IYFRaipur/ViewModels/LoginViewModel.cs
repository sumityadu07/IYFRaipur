using IYFRaipur.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;
using MvvmHelpers.Commands;
using System;
using IYFRaipur.Views;
using IYFRaipur.Models;

namespace IYFRaipur.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        #region Authentication
        private string phone;
        private string code;
        private bool codeSent;
        private string buttonText = "Next";
        public bool codeRequested;
        IAuthService authService = DependencyService.Resolve<IAuthService>();
        #endregion
        async Task OnNextAction()
        {
            if (codeRequested)
            {
                if (string.IsNullOrWhiteSpace(code) && code.Length != 6)
                {
                    await Shell.Current.DisplayAlert("ERROR", "Please recheck the code entered", "OK");
                }
                bool codeVerified = await authService.VerifyOtpCodeAsync(Code);
                if (codeVerified)
                {
                    await Shell.Current.GoToAsync("//MainPage");

                }
                await Shell.Current.DisplayAlert("ERROR", "Please choose the type of account you are logging to", "OK");


            }
            else
            {
                if (string.IsNullOrWhiteSpace(phone) && phone.Length != 10)
                {
                    await Shell.Current.DisplayAlert("Error", "Please enter a valid phone number", "Ok");
                }
                CodeSent = await authService.SendOtpCodeAsync(Phone);

                if (!CodeSent)
                    return;
                codeRequested = true;
                ButtonText = "Verify Code";
            }
        }

        #region Properties

        public string Phone
        {
            get => phone;
            set => SetProperty(ref phone, value);
        }

        public string Code
        {
            get => code;
            set => SetProperty(ref code, value);
        }

        public bool CodeSent
        {
            get => codeSent;
            set => SetProperty(ref codeSent, value);
        }

        public string ButtonText
        {
            get => buttonText;
            set => SetProperty(ref buttonText, value);
        }
        #endregion

        #region Commands
        public ICommand NextCommand => new AsyncCommand(OnNextAction);
        #endregion
    }
}