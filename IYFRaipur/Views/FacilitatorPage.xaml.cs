using IYFRaipur.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IYFRaipur.Views
{
    public partial class FacilitatorPage : ContentPage
    {
        FacilitatorViewModel _viewModel;

        public FacilitatorPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new FacilitatorViewModel();
        }

    }
}