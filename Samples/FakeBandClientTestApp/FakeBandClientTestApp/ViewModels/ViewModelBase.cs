using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FakeBandClientTestApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool Set<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        private bool? _record;

        public bool? Record
        {
            get { return _record; }
            set { Set(ref _record , value); }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
