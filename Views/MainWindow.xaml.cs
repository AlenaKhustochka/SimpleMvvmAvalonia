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
using SimpleMvvmAvalonia.ViewModels;

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
    }
}