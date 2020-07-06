using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfAnniversaryReminderApp.ViewModel;

namespace WpfAnniversaryReminderApp.Commands
{
   public class ProfileCommand:ICommand
    {
        private HomeViewModel _homeViewModel;
        public ProfileCommand(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _homeViewModel.MyProfile();
        }
    }
}
