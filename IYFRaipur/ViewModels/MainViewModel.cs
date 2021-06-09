using IYFRaipur.Models;
using IYFRaipur.Services;
using IYFRaipur.Views;
using System.Linq;
using MvvmHelpers.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;

namespace IYFRaipur.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        IUserData userData = DependencyService.Resolve<IUserData>();
        public MainViewModel()
        {
            IsUserSignedInAsync();
        }
        async void IsUserSignedInAsync()
        {
            var authService = DependencyService.Resolve<IAuthService>();
            if (!authService.IsSignIn())
            {
                await Shell.Current.GoToAsync("//LoginPage");
            }
        }


        public ICommand Councelor => new AsyncCommand(GoToCouncelorPage);
        public ICommand Preacher => new AsyncCommand(GoToPreacherPage);
        public ICommand Facilitator => new AsyncCommand(GoToFacilitatorPage);

        async Task GoToCouncelorPage()
        {
            await Shell.Current.GoToAsync(nameof(CounselorPage));
        }
        async Task GoToPreacherPage()
        {
            try
            {
                userData.Save("Preacher");
                await Shell.Current.GoToAsync(nameof(PreacherPage));
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine($"Unable to get Data: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
        async Task GoToFacilitatorPage()
        {
            userData.Save("Facilitator");
            await Shell.Current.GoToAsync(nameof(FacilitatorPage));
        }
    }
}
