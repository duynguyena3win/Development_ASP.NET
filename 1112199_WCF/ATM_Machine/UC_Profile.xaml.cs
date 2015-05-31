using ATM_Machine.ServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATM_Machine
{
    /// <summary>
    /// Interaction logic for UC_Profile.xaml
    /// </summary>
    public partial class UC_Profile : UserControl, INotifyPropertyChanged
    {
        public delegate void Click();
        public event Click BackClick;

        Account _myAccount;
        public Account MyAccount
        {
            get { return _myAccount; }
            set { _myAccount = value; OnPropertyChanged("MyAccount"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public UC_Profile()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackClick();
        }
    }
}
