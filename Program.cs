using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;

namespace SimpleMvvmAvalonia
{
    class Program
    {
        public static void Main(string[] args)
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                         .UsePlatformDetect()
                         .UseSkia();
    }
}