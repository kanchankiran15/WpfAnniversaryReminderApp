using System;
using System.Windows;
using WpfAnniversaryReminderApp.Commands;
using WpfAnniversaryReminderApp.Common;
using WpfAnniversaryReminderApp.DAL;
using WpfAnniversaryReminderApp.Model;

namespace WpfAnniversaryReminderApp.ViewModel
{
    public class MyProfileViewModel : ViewModelBase
    {
        #region PROPERTIES
        private string txtName;
        private DateTime dtpDOJ;
        private DateTime dtpDOB;
        private string txtPhone;
        private string imgSource;

        public string TxtName { get => _employee.Name; set { _employee.Name = value; OnPropertyChanged(TxtName); } }
        public DateTime DtpDOJ
        {
            get => Convert.ToDateTime(_employee.DOJ); set
            {
                _employee.DOJ = value.ToString();
                OnPropertyChanged(DtpDOJ.ToString());
            }
        }
        public DateTime DtpDOB
        {
            get => Convert.ToDateTime(_employee.DOB); set
            {
                _employee.DOB = value.ToString();
                OnPropertyChanged(DtpDOB.ToString());
            }
        }
        public string TxtPhone { get => _employee.Phone; set { _employee.Phone = value; OnPropertyChanged(TxtPhone); } }
        public string ImgSource { get => imgSource; set => imgSource = value; }
        #endregion
        Employee _employee = new Employee();
        private SaveProfileCommand _saveProfileCommand;
        public MyProfileViewModel()
        {
            _saveProfileCommand = new SaveProfileCommand(this);
            loadMyProfile();
        }


        #region command

        public System.Windows.Input.ICommand SaveCmd
        {
            get
            {
                return _saveProfileCommand;
            }
        }

        #endregion

        #region "Action"
        public void loadMyProfile()
        {
            if (Global.IsLogin)
            {
                _employee.Email = Global.Email;
                DataContext context = new DataContext(_employee);
                context.getEmployeeById();
                TxtName = _employee.Name;
                TxtPhone = _employee.Phone;
                DtpDOB = Convert.ToDateTime(_employee.DOB);
                DtpDOJ = Convert.ToDateTime(_employee.DOJ);
                ImgSource = "C:\\Development\\WpfAnniversaryReminderApp\\img\\123.jpg"; 
            }
        }
        public void Save()
        {
            if (Global.IsLogin)
            {
                DataContext context = new DataContext(_employee);
                if (context.SaveEmployee())
                {
                    MessageBox.Show("Data has been saved successfully..!!");
                }
                else
                {
                    MessageBox.Show("there is an issue with database connection");
                }
            }
            else
            {
                 Console.WriteLine("Login Expired");
            }
           

        }
        #endregion
    }
}
