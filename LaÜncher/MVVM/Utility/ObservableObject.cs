using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace USoftware_HUb.MVVM.Utility
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = default)
        {
            MessageBox.Show($"Property changed: {name}");

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
