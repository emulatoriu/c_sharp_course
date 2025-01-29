using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRelayCommandTest.Data
{
    public class TextWrapper : INotifyPropertyChanged
    {
        string _ShowedText;
        public string ShowedText
        {
            get
            {
                return _ShowedText;
            }
            set
            {
                _ShowedText = value;
                OnPropertyChanged(nameof(ShowedText));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
