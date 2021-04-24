using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SimpleMvvmAvalonia.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));

            return true;
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
    }
}