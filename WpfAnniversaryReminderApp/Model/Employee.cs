using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfAnniversaryReminderApp.Model
{
    public class Employee// : INotifyPropertyChanged
    {
        private string _Name;
        private string _Email;
        private string _DOJ;
        private string _DOB;
        private string _Phone;
        private string _PhotoPath;
        private string _Password;
        private bool _IsValid;

        public string Name { get => _Name; set { _Name = value; } }
        public string Email { get => _Email; set { _Email = value; } }

        public string DOJ { get => _DOJ; set { _DOJ = value; } }
        public string DOB { get => _DOB; set { _DOB = value; } }
        public string Phone { get => _Phone; set { _Phone = value; } }
        public string PhotoPath { get => _PhotoPath; set { _PhotoPath = value; } }
        public string Password { get => _Password; set { _Password = value; } }

        public bool IsValid { get => _IsValid; set => _IsValid = value; }

        //#region INotifyPropertyChanged Members  

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        //#endregion
    }
}
