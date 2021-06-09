using IYFRaipur.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IYFRaipur.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainViewModel();

        }

    }
}