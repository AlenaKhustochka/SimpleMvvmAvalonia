using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Input;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;

namespace SimpleMvvmAvalonia.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async void OnChooseFileClick(object sender, RoutedEventArgs e)
        {
            var window = new OpenFileDialog()
            {
                Title = "Выбор файла"
            };
            window.AllowMultiple = false;
            var result = await window.ShowAsync(this);
            if (result.Length != 0)
            {
                dynamic viewModel = DataContext;
                viewModel.SelectedFile(result[0]);
            }
        }
    }
}