using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace SalonKrasotyDescktop.Views.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddRegistration.xaml
    /// </summary>
    public partial class AddRegistration : Window
    {
        public AddRegistration()
        {
            InitializeComponent();
        }

        private void TextBoxStartTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*if (TextBoxStartTime.Text.Length == 2)
            {
                if (Convert.ToInt32(TextBoxStartTime.Text) > 24)
                {
                    MessageBox.Show("Количество часов в сутках 24");
                    TextBoxStartTime.Text = "";
                }
                else
                {
                    
                        TextBoxStartTime.Text += ":";
                        TextBoxStartTime.SelectionStart = TextBoxStartTime.Text.Length;
                        TextBoxStartTime.SelectionLength = 0;
                    
                }
            }*/
        }

        private void TextBoxStartTime_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            /*if(Regex.IsMatch(e.Text, @"[^1234567890]"))
            {
                e.Handled = true;
            }*/
            //MessageBox.Show(e.Text);
            /*if (TextBoxStartTime.Text.Length == 2)
            {
                if (Convert.ToInt32(TextBoxStartTime.Text) > 24)
                {
                    MessageBox.Show("Количество часов в сутках 24");
                    TextBoxStartTime.Text = "";
                }
                else
                {

                    TextBoxStartTime.Text += ":";
                    TextBoxStartTime.SelectionStart = TextBoxStartTime.Text.Length;
                    TextBoxStartTime.SelectionLength = 0;

                }
            }*/
        }

        private void TextBoxStartTime_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                e.Handled = false;
                return;
            }
            if (!Enum.IsDefined(typeof(Keys), e.Key.ToString()))
            {
               e.Handled = true;
               return;
            }
            if (TextBoxStartTime.Text.Length == 2)
            {
               TextBoxStartTime.Text += ":";
               TextBoxStartTime.SelectionStart = TextBoxStartTime.Text.Length;
               TextBoxStartTime.SelectionLength = 0;
            }
            if(TextBoxStartTime.Text.Length >= 5)
            {
                MessageBox.Show("Время должно содержать 5 символов");
                e.Handled = true;
            }
        }

        private enum Keys
        {
            D1,D2,D3,D4,D5,D6,D7,D8,D9,D0
        }

    }
}
