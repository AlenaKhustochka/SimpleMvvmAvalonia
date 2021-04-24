using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using Avalonia.Threading;
using SimpleMvvmAvalonia.Interfaces;
using SimpleMvvmAvalonia.Models;
using SimpleMvvmAvalonia.Commands;

namespace SimpleMvvmAvalonia.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        private IModel Model;
        private ObservableCollection<string> Logs;
        private Thread ThreadDatabase;
        private bool IsThreadRunning;
        private string File;
        private int CountOfPressCat;

        public bool IsThreadRunningProperty
        {
            get { return IsThreadRunning; }
            set { SetProperty(ref IsThreadRunning, value); }
        }
        public int CountOfPressCatProperty
        {
            get { return CountOfPressCat; }
        }
        public ObservableCollection<string> LogsProperty
        {
            get { return Logs; }
            set { SetProperty(ref Logs, value); }
        }
        public RelayCommand OnWriteFileClick
        {
            get { return new RelayCommand(OnWriteFile); }
        }

        public RelayCommand<int> OnCatButtonClick
        {
            get { return new RelayCommand<int>(param => IncrementCountOfPressCatButton(param)); }
        }

        public ViewModel(IModel model)
        {
            Model = model;
            Model.AddLog += this.AddLog;
            Model.Finished += this.ChangeActivityUI;
            Logs = new ObservableCollection<string>();
            CountOfPressCat = 0;
            ThreadDatabase = null;
        }

        public void SelectedFile(string file)
        {
            File = file;
            Console.WriteLine($"file: {File}");
        }

        private void IncrementCountOfPressCatButton(int count)
        {
            CountOfPressCat++;

            var number = CountOfPressCat % 100;
            if (number >= 11 && number <= 19)
            {
                AddLog($"Осуществлено {CountOfPressCat} нажатий на котика");
                return;
            }
            var i = number % 10;
            switch (i)
            {
                case 1:
                    AddLog($"Осуществлено {CountOfPressCat} нажатие на котика");
                    break;
                case 2:
                case 3:
                case 4:
                    AddLog($"Осуществлено {CountOfPressCat} нажатия на котика");
                    break;
                default:
                    AddLog($"Осуществлено {CountOfPressCat} нажатий на котика");
                    break;
            }
        }

        private void OnWriteFile()
        {
            Logs.Clear();
            IsThreadRunningProperty = true;
            ThreadDatabase = new Thread(new ThreadStart(StartWriteFileAsync));
            ThreadDatabase.Start();
        }

        private void StartWriteFileAsync()
        {
            Model.WriteFileAsync(File);
        }

        private void AddLog(string message)
        {
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                Logs.Add(message);
            });
        }

        private void ChangeActivityUI()
        {
            IsThreadRunningProperty = !IsThreadRunningProperty;
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                ThreadDatabase.Join();
                ThreadDatabase = null;
            });
        }
    }
}