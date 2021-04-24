using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using SimpleMvvmAvalonia.Models;
using SimpleMvvmAvalonia.Views;
using SimpleMvvmAvalonia.ViewModels;

namespace SimpleMvvmAvalonia
{
    public class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow()
                {
                    DataContext = new ViewModel(new Model())
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}