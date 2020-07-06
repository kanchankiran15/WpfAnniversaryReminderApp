using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfAnniversaryReminderApp.Model
{
    class MainWindowModel: BindableBase
    {
        private Visibility _ControlVisibilty;
        public Visibility ControlVisibilty { get { return _ControlVisibilty; } set { SetProperty(ref _ControlVisibilty, value); } }
    }
}
