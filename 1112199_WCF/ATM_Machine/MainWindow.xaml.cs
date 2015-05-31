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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string idaccount = null;

        Account _currentAccount;

        public Account CurrentAccount
        {
            get { return _currentAccount; }
            set { _currentAccount = value; OnPropertyChanged("CurrentAccount"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        ServiceReference.BankServiceClient Client = null;
        string TypeConnection;
        public MainWindow()
        {
            InitializeComponent();
            TypeConnection = "basic";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TypeConnection = "tcp";
            Page1.Visibility = System.Windows.Visibility.Hidden;
            Page2.Visibility = System.Windows.Visibility.Visible;
            Client = new ServiceReference.BankServiceClient(TypeConnection);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TypeConnection = "ws";
            Page1.Visibility = System.Windows.Visibility.Hidden;
            Page2.Visibility = System.Windows.Visibility.Visible;
            Client = new ServiceReference.BankServiceClient(TypeConnection);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Client.LogIn(Edit_IdCard.Text, Edit_Pin.Password))
                {
                    idaccount = Client.GetIdAccount(Edit_IdCard.Text);
                    Page2.Visibility = System.Windows.Visibility.Hidden;
                    Page3.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("The Id card or pin, you entered did not match our records!", "Sign In", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("WCF Service doesn't start!");
            }
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Btn_Profile_Click(object sender, RoutedEventArgs e)
        {
            CurrentAccount = Client.LoadProfile(idaccount);
            Page3.Visibility = System.Windows.Visibility.Hidden;
            PageProfile.Visibility = System.Windows.Visibility.Visible;
            PageProfile.MyAccount = CurrentAccount;
        }

        private void PageProfile_BackClick()
        {
            Page3.Visibility = System.Windows.Visibility.Visible;
            PageProfile.Visibility = System.Windows.Visibility.Hidden;
        }

        private void PageGetFunds_BackClick(Int64 type)
        {
            bool bstop = false;

            if (type == -1)
                bstop = true;
            else
            {
                if (Client.GetFunds(idaccount, type))
                {
                    if (MessageBox.Show("Succesful, you get " + type + " VND !Do you want continue get funds?", "Notification", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        bstop = true;
                    else
                        bstop = false;
                }
                else
                    MessageBox.Show("Not enough money!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if(bstop == true)
            {
                Page3.Visibility = System.Windows.Visibility.Visible;
                PageGetFunds.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void Btn_GetFunds_Click(object sender, RoutedEventArgs e)
        {
            Page3.Visibility = System.Windows.Visibility.Hidden;
            PageGetFunds.Visibility = System.Windows.Visibility.Visible;
        }

        private void Btn_TransferFunds_Click(object sender, RoutedEventArgs e)
        {
            Page3.Visibility = System.Windows.Visibility.Hidden;
            PageTransfer.Visibility = System.Windows.Visibility.Visible;
        }

        private void PageTransfer_TransferClick(string idacc, long funds)
        {
            if(idacc == null && funds == 0)
            {
                Page3.Visibility = System.Windows.Visibility.Visible;
                PageTransfer.Visibility = System.Windows.Visibility.Hidden;
                return;
            }

            if(idaccount == idacc)
            {
                MessageBox.Show("Can't transfer for yourseft Account!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if(!(funds % 50000 == 0 && funds > 53000))
            {
                MessageBox.Show("Funds not incorret!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (Client.CheckAccount(idacc))
            {
                if (Client.GetFunds(idaccount, funds + 3000))
                {
                    Client.GetFunds(idacc, -funds);
                    MessageBox.Show("Succeessful, Transfer done!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    Page3.Visibility = System.Windows.Visibility.Visible;
                    PageTransfer.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                    MessageBox.Show("Your Account is not enough money!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Account doesn't have in Database!", "Notification", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void Btn_SignOut_Click(object sender, RoutedEventArgs e)
        {
            Edit_IdCard.Text = Edit_Pin.Password = string.Empty;
            idaccount = null;
            Page3.Visibility = System.Windows.Visibility.Hidden;
            Page2.Visibility = System.Windows.Visibility.Visible; 
        }

        private void Edit_IdCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Edit_IdCard.Text != string.Empty && Edit_Pin.Password != string.Empty)
                Button_SignIn.IsEnabled = true;
            else
                Button_SignIn.IsEnabled = false;
        }

        private void Edit_Pin_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (Edit_IdCard.Text != string.Empty && Edit_Pin.Password != string.Empty)
                Button_SignIn.IsEnabled = true;
            else
                Button_SignIn.IsEnabled = false;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
