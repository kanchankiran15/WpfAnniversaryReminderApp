using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WpfAnniversaryReminderApp.Commands;
using WpfAnniversaryReminderApp.DAL;
using WpfAnniversaryReminderApp.Model;

namespace WpfAnniversaryReminderApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private LoginCommand _loginCommand;
        private string _errorMessage;
        Employee _employee = new Employee();
        public LoginViewModel()
        {
            _loginCommand = new LoginCommand(this);
        }

        public string txtEmail
        {
            get { return _employee.Email; }
            set
            {
                _employee.Email = value;
                OnPropertyChanged(txtEmail);
            }
        }

        public string errorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(errorMessage);
            }
        }

        public string txtPassword
        {
            get { return _employee.Password; }
            set { _employee.Password = value; }
        }


        // handle login click event
        // if login is not successfull send error message
        // else direct the user to home page
        #region Command

        public ICommand LoginCmd
        {
            get
            {
                return _loginCommand;
            }
        }
        #endregion
        #region"Methods"
        internal void Login()
        {
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(_employee.Email) || string.IsNullOrEmpty(_employee.Password))
            {
                errorMessage = "Please enter a valid user name";
                MessageBox.Show(errorMessage);
            }
            else
            {
                DataContext context = new DataContext(_employee);
                context.Login();
                Common.Global.IsLogin = _employee.IsValid;

                if (_employee.IsValid)
                {
                    Common.Global.Email = _employee.Email;
                    MainWindowViewModel model= new MainWindowViewModel(_employee.IsValid, false);
                    Windows.HomeWindow home = new Windows.HomeWindow();
                    home.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    //MainWindow main = new MainWindow();
                    //main.DataContext = model;
                    //main.Show();
                    home.Show();
                }
                else
                {
                    errorMessage = "Authentication Failed";
                   MessageBox.Show(errorMessage);

                }
            }
        }
        #endregion
    }
}
