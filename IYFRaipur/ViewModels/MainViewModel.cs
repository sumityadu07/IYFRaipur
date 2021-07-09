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
        public MainViewModel()
        {
            IsUserSignedInAsync();
        }
        async void IsUserSignedInAsync()
        {
            var authService = DependencyService.Resolve<IAuthentication>();
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
            await Shell.Current.GoToAsync(nameof(PreacherPage));
        }
        async Task GoToFacilitatorPage()
        {
            await Shell.Current.GoToAsync(nameof(FacilitatorPage));
        }
    }
}
