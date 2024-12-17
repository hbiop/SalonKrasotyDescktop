using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.ViewModels.Interfaces;
using SalonKrasotyDescktop.ViewModels.Realizations;
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
        private IClientViewModel clientViewModel;
        private IClientServiceViewModel clientServiceViewModel;
        ServiceDto service;
        public AddRegistration(ServiceDto serviceDto)
        {
            InitializeComponent();
            service = serviceDto;
            clientViewModel = new ClientViewModel();
            clientServiceViewModel = new ClientServiceViewModel();
            TextBoxDuration.Text = serviceDto.Time.ToString();
            TextBoxServiceTitle.Text = serviceDto.Title;
            CmbClients.DataContext = clientViewModel;
            DatePicker.Text = DateTime.Now.ToString();        
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
                e.Handled = true;
            }
        }

        private enum Keys
        {
            D1,D2,D3,D4,D5,D6,D7,D8,D9,D0
        }

        private void AddRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if(DateTime.TryParse((DatePicker.Text + " " + TextBoxStartTime.Text), out DateTime dateTime))
            {
                ClientService clientService = new ClientService
                {
                    ClientID = clientViewModel.clients[CmbClients.SelectedIndex].Id,
                    ServiceID = service.Id,
                    StartTime = dateTime
                };
                clientServiceViewModel.AddClientService(clientService);
            }
            else
            {
                if(!DateTime.TryParse((DatePicker.Text + " " + TextBoxStartTime.Text), out DateTime dt))
                {
                    MessageBox.Show("Дата или время было в неверном формате");
                }
            } 
        }
    }
}
