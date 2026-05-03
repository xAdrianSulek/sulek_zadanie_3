using sulek_zadanie_3.ViewModels;

namespace sulek_zadanie_3.Views
{
    public partial class SecondPage : ContentPage
    {
        public SecondPage(SecondPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
