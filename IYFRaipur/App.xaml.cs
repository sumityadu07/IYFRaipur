using IYFRaipur.Services;
using IYFRaipur.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IYFRaipur
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
           
        }
        //fcnlpngqztvdsjyr
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
