using Microsoft.Extensions.Logging;
using sulek_zadanie_3.Services;
using sulek_zadanie_3.ViewModels;
using sulek_zadanie_3.Views;

namespace sulek_zadanie_3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ITransactionStore, JsonTransactionStore>();

            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddTransient<SecondPageViewModel>();
            builder.Services.AddTransient<SecondPage>();

            builder.Services.AddTransient<ThirdPageViewModel>();
            builder.Services.AddTransient<ThirdPage>();

            builder.Services.AddTransient<FourthPageViewModel>();
            builder.Services.AddTransient<FourthPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
