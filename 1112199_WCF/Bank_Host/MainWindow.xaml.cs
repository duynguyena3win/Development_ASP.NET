using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace Bank_Host
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost BankHost;
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                BankHost = new ServiceHost(typeof(BankService));
                BankHost.Open();
                TextBlock mytext = new TextBlock();
                mytext.Foreground = Brushes.White;
                mytext.Text = " * " + DateTime.Now.ToString() + " -- " + "Service is running! ";
                mytext.FontSize = 13;
                mytext.FontFamily = new FontFamily(new Uri("pack://application:,,,/agency_fb.ttf"), "Agency_FB");
                MyStack.Children.Add(mytext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Bank_Host.BankService client = new BankService();
            //client.GetFunds("1112199", 100000);
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            BankHost.Close();
        }
    }
}
