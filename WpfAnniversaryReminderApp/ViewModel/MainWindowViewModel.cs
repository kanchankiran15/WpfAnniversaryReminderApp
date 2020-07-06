using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfAnniversaryReminderApp.Model;

namespace WpfAnniversaryReminderApp.ViewModel
{
   public class MainWindowViewModel
    {
        MainWindowModel _model;
        bool _isLogin = false;
        bool _isProfile = false;
        private Visibility _LoginVisibility;
        private Visibility _HomeVisibility;
        private Visibility _ProfileVisibility;
        public Visibility LoginVisibility { get => _LoginVisibility; set => _LoginVisibility = value; }
        public Visibility HomeVisibility { get => _HomeVisibility; set => _HomeVisibility = value; }
        public Visibility ProfileVisibility { get => _ProfileVisibility; set => _ProfileVisibility = value; }

        public MainWindowViewModel()
        {
            _model = new MainWindowModel();
            UserControlsVisible();
        }
        public MainWindowViewModel(bool isLogin, bool isProfile = false)
        {
            _isLogin = isLogin;
            _isProfile = isProfile;
            UserControlsVisible();
        }   

        private void UserControlsVisible()
        {
            _LoginVisibility = (_isLogin) ? Visibility.Hidden : Visibility.Visible;
            _HomeVisibility = (_isLogin) ? Visibility.Visible : Visibility.Hidden;
            _ProfileVisibility = (_isProfile) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
