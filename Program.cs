using Avalonia;
using System;

namespace TaxiApp
{
    internal class Program
    {
        // Dasturning asosiy kirish nuqtasi
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia ilovasini sozlash va tayyorlash
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();
    }
}
