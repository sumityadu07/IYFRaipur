using IYFRaipur.Services;
using IYFRaipur.ViewModels;
using IYFRaipur.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IYFRaipur
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CounselorPage), typeof(CounselorPage));
            Routing.RegisterRoute(nameof(FacilitatorPage), typeof(FacilitatorPage));
            Routing.RegisterRoute(nameof(PreacherPage), typeof(PreacherPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            IAuthService authService = DependencyService.Resolve<IAuthService>();
            authService.SignOut();
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
