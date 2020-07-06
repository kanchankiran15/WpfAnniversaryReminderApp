using System;
using System.Windows.Input;
using WpfAnniversaryReminderApp.ViewModel;

namespace WpfAnniversaryReminderApp.Commands
{
    public class SaveProfileCommand : ICommand
    {
        private MyProfileViewModel _model;
        public SaveProfileCommand(MyProfileViewModel model)
        {
            _model = model;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _model.Save();
        }
    }
}
