using sulek_zadanie_3.ViewModels;

namespace sulek_zadanie_3.Views
{
    public partial class FourthPage : ContentPage
    {
        public FourthPage(FourthPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
