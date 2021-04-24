using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using Avalonia.Threading;
using SimpleMvvmAvalonia.Interfaces;
using SimpleMvvmAvalonia.Models;

namespace SimpleMvvmAvalonia.ViewModels
{
    public class ViewModel : ViewModelBase
    {
        private IModel Model;

        public ViewModel(IModel clientModel)
        {
            Model = clientModel;
        }
    }
}