using sulek_zadanie_3.ViewModels;

namespace sulek_zadanie_3.Views
{
    public partial class ThirdPage : ContentPage
    {
        public ThirdPage(ThirdPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
