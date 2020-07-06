using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfAnniversaryReminderApp.ViewModel;

namespace WpfAnniversaryReminderApp.Commands
{
    public class LoginCommand : ICommand
    {
        private LoginViewModel _loginViewModel;
        public LoginCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            //if (string.IsNullOrEmpty(_loginViewModel.txtEmail))
            //{
            //    _loginViewModel.errorMessage = "UserName field value is Invalid";
            //    return false;
            //}

            return true;
        }

        public void Execute(object parameter)
        {
            _loginViewModel.Login();
        }
    }
}
