using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WpfAnniversaryReminderApp.Commands;
using WpfAnniversaryReminderApp.Common;
using WpfAnniversaryReminderApp.DAL;
using WpfAnniversaryReminderApp.Model;

namespace WpfAnniversaryReminderApp.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private ProfileCommand _profileCommand;
       
        
        public HomeViewModel()
        {
            _profileCommand = new ProfileCommand(this);
            GetAnniversaries();
        }

        #region Properties

        private Employee _emp;
        public Employee Emp
        {
            get => _emp;
            set
            {
                _emp = value;
                OnPropertyChanged("Emp");
            }
        }

        private List<Employee> _anniversariesList;
        public List<Employee> AnniversariesList
        {
            get => _anniversariesList;
            set
            {
                _anniversariesList = value;
                OnPropertyChanged("AnniversariesList");
            }
        }
       
        private string _btnMyProfile = "My Profile";
        public string btnMyProfile
        {
            get
            {
                return Common.Global.Email;
            }
            set { _btnMyProfile = value; }
        }
        #endregion

        #region command

        public System.Windows.Input.ICommand ProfileCmd
        {
            get
            {
                return _profileCommand;
            }
        }

        #endregion

        #region "Action"

        public void GetAnniversaries()
        {
            if (Global.IsLogin)
            {
                DataContext context = new DataContext(Emp);
                AnniversariesList = context.GetAnniversaries();
                if (AnniversariesList.Count < 1) { MessageBox.Show("no anniversaries...!"); }
            }
            else
            {
                 Console.WriteLine("Login Expired");
            }
            
        }

        public void MyProfile()
        {
            if (Global.IsLogin)
            {
                Windows.ProfileWindow profile = new Windows.ProfileWindow();
                profile.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                profile.Show();
            }
            else
            {
                Console.WriteLine("Login Expired");
            }
        }
        #endregion

    }
}
