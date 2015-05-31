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
    /// Interaction logic for UC_Transfer.xaml
    /// </summary>
    public partial class UC_Transfer : UserControl
    {
        public delegate void Click(string idaccount, Int64 funds);
        public event Click TransferClick;
        public UC_Transfer()
        {
            InitializeComponent();
        }

        private void Button_OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TransferClick(Textbox_IdCard.Text, Convert.ToInt64(Textbox_Funds.Text));
                Textbox_Funds.Text = Textbox_IdCard.Text = string.Empty;
            }
            catch
            { }
        }

        private void Textbox_IdCard_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Textbox_IdCard.Text != string.Empty && Textbox_Funds.Text != string.Empty)
                Button_OK.IsEnabled = true;
            else
                Button_OK.IsEnabled = false;
        }

        private void Textbox_Funds_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Textbox_IdCard.Text != string.Empty && Textbox_Funds.Text != string.Empty)
                    Button_OK.IsEnabled = true;
                else
                    Button_OK.IsEnabled = false;
                Convert.ToInt64(Textbox_Funds.Text);
            }
            catch
            {
                MessageBox.Show("Only number 0-9 and multiple of 50 000 VND");
            }
        }

        private void Button_Cancle_Click(object sender, RoutedEventArgs e)
        {
            TransferClick(null, 0);
            Textbox_Funds.Text = Textbox_IdCard.Text = string.Empty;
        }
    }
}
