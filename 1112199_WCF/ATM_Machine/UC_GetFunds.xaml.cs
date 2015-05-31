using System;
using System.Collections.Generic;
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
    /// Interaction logic for UC_GetFunds.xaml
    /// </summary>
    public partial class UC_GetFunds : UserControl
    {
        public delegate void Click(Int64 type);
        public event Click BackClick;

        public UC_GetFunds()
        {
            InitializeComponent();
        }

        private void Btn_1Million_Click(object sender, RoutedEventArgs e)
        {
            BackClick(1000000);
        }

        private void Btn_2Million_Click(object sender, RoutedEventArgs e)
        {
            BackClick(2000000);
        }

        private void Btn_5Million_Click(object sender, RoutedEventArgs e)
        {
            BackClick(5000000);
        }

        private void Btn_Another_Click(object sender, RoutedEventArgs e)
        {
            Grid_GetFunds.Visibility = System.Windows.Visibility.Hidden;
            Grid_Another.Visibility = System.Windows.Visibility.Visible;
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            BackClick(-1);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            Int64 funds = Convert.ToInt64(Textbox_Funds.Text);
            if (funds % 50000 == 0 && funds > 0)
            {
                Grid_GetFunds.Visibility = System.Windows.Visibility.Visible;
                Grid_Another.Visibility = System.Windows.Visibility.Hidden;
                BackClick(funds);
            }
        }
    }
}
