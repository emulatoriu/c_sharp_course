using MVVM_WIFI_Teilnehmer.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVM_WIFI_Teilnehmer.ViewModel
{
    class UserViewModel /* INotifyPropertyChanged*/
    {
        public ObservableCollection<User> _UsersList { get; set; }

        //private bool _isDeleteEnabled;
        //public bool IsDeleteEnabled {
        //    get
        //    {
        //        return _isDeleteEnabled;
        //    }
        //    set
        //    {
        //        _isDeleteEnabled = _UsersList.Count > 3;
        //        OnPropertyChanged(nameof(IsDeleteEnabled));
        //    }
        //}

        //public event PropertyChangedEventHandler? PropertyChanged;

        //public void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        public ICommand UpdateCommand { get; set; }
        public ICommand mySave { get; set; }
        public ICommand myDelete { get; set; }

        public UserViewModel()
        {
            _UsersList = new ObservableCollection<User>
            {
                new User{UserId = 1,FirstName="Mickey",LastName="Mouse",City="Orlando",State="FLO",Country="USA"},
                new User{UserId=2,FirstName="Bugs",LastName="Bunny",City="Wien", State="VIE", Country="AUSTRIA"},
                new User{UserId=3,FirstName="Arnold",LastName="Schwarzenegger",City="Washington", State="W", Country="USA"},
                new User{UserId=4,FirstName="Tom",LastName="Cat",City="", State="", Country="USA"},
                new User{UserId=5,FirstName="Bat",LastName="Man",City="Gottham City", State="", Country="USA"},                
            };

            UpdateCommand = new Updater();
            mySave = new Save();
            myDelete = new Delete(_UsersList);

        }



        private class Updater : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return false;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                //Console.WriteLine("Update");
                MessageBox.Show("Update");
                //Do update function
            }

            #endregion
        }

        private class Save : ICommand
        {
            #region ICommand Members  

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Console.WriteLine("Save");
                MessageBox.Show("Save");
                //_UsersList.RemoveAt(0);
                //Do saving function
            }

            #endregion
        }

        private class Delete : ICommand
        {
            #region ICommand Members  
            public ObservableCollection<User> _UsersList { get; set; }
            public bool buttonEnabled { get; set; }
            public Delete(ObservableCollection<User> _UsersList)
            {
                this._UsersList = _UsersList;
                this.buttonEnabled = buttonEnabled;
            }

            public bool CanExecute(object? parameter)
            {                
                return _UsersList.Count > 3;
            }

            public event EventHandler? CanExecuteChanged;

            public void Execute(object? parameter)
            {
                Console.WriteLine("Delete");
                MessageBox.Show("Delete " + ((User)parameter).FirstName);
                _UsersList.Remove(((User)parameter));
                CanExecuteChanged?.Invoke(this, new EventArgs());
                //Delete Function
            }

            #endregion
        }
    }
}
