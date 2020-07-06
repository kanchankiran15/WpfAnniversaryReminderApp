using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfAnniversaryReminderApp.ViewModel;

namespace WpfAnniversaryReminderApp.Commands
{
    public class ButtonCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           
        }
    }

    //public class SaveCommand : ButtonCommand
    //{
    //    private MyProfileViewModel _model;
    //    public SaveCommand(MyProfileViewModel model)
    //    {
    //        _model = model;
    //    }
    //    public void Execute(object parameter)
    //    {
    //        _model.Save();
    //    }
    //}
}
