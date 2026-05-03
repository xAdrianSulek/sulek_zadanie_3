using sulek_zadanie_3.Views;

namespace sulek_zadanie_3
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("SecondPage", typeof(SecondPage));
            Routing.RegisterRoute("ThirdPage", typeof(ThirdPage));
            Routing.RegisterRoute("FourthPage", typeof(FourthPage));
        }
    }
}
