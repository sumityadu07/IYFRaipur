using IYFRaipur.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IYFRaipur.Views
{
    public partial class CounselorPage : ContentPage
    {
        CouncelorViewModel _viewModel;

        public CounselorPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new CouncelorViewModel();
        }

    }
}