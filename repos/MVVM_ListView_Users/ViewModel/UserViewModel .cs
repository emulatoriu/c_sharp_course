using MVVM_ListView_Users.Controls;
using MVVM_ListView_Users.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_ListView_Users.ViewModel
{
    public class UserViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> Users { get; set; }

        private string _newUserName;
        private string _newUserEmail;
        private DateTime _newUserDateOfBirth;

        public string NewUserName
        {
            get { return _newUserName; }
            set
            {
                _newUserName = value;
                OnPropertyChanged(nameof(NewUserName));
                AddUserCommand.RaiseCanExecuteChanged();
            }
        }

        public string NewUserEmail
        {
            get { return _newUserEmail; }
            set
            {
                _newUserEmail = value;
                OnPropertyChanged(nameof(NewUserEmail));
                AddUserCommand.RaiseCanExecuteChanged();
            }
        }

        public DateTime NewUserDateOfBirth
        {
            get { return _newUserDateOfBirth; }
            set
            {
                _newUserDateOfBirth = value;
                OnPropertyChanged(nameof(NewUserDateOfBirth));
                AddUserCommand.can();
            }
        }

        public ICommand AddUserCommand { get; private set; }
        public ICommand DeleteUserCommand { get; private set; }

        public UserViewModel()
        {
            Users = new ObservableCollection<User>();

            AddUserCommand = new RelayCommand(
                () =>
                {
                    Users.Add(new User()
                    {
                        Name = NewUserName,
                        Email = NewUserEmail,
                        DateOfBirth = NewUserDateOfBirth
                    });

                    NewUserName = "";
                    NewUserEmail = "";
                    NewUserDateOfBirth = DateTime.Today;
                },
                () =>
                {
                    return !string.IsNullOrEmpty(NewUserName) &&
                           !string.IsNullOrEmpty(NewUserEmail) &&
                           NewUserDateOfBirth < DateTime.Today;
                });

            DeleteUserCommand = new RelayCommand(
                (selectedItem) =>
                {
                    Users.Remove((User)selectedItem);
                },
                (selectedItem) =>
                {
                    return selectedItem != null && Users.Contains((User)selectedItem);
                });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
