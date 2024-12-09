using SalonKrasotyDescktop.entities;
using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.ViewModels;
using SalonKrasotyDescktop.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalonKrasotyDescktop.views.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        IServiceViewModel viewModel;
        public AddUser(IServiceViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            ButtonAdd.Content = "Добавить";
            tbId.Visibility = Visibility.Hidden;
            lbId.Visibility = Visibility.Hidden;
            ButtonAdd.Click += ButtonAdd_Click;
        }
        ServiceDto service;
        public AddUser(IServiceViewModel viewModel, ServiceDto service)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.service = service;
            tbId.Text = service.Id.ToString();
            tbNazvanie.Text = service.Title;
            tbDlitelnost.Text = service.Time.ToString();
            tbOpisanie.Text = service.Description;
            tbSkidka.Text = service.Discount.ToString();
            tbStoimost.Text = service.NewCost.ToString();
            ButtonAdd.Content = "Изменить";
            ButtonAdd.Click += ButtonChange_Click;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(tbDlitelnost.Text, out int dlitelnost) 
                && double.TryParse(tbSkidka.Text, out double skidka) 
                && decimal.TryParse(tbStoimost.Text, out decimal stoimost)
            )
            {
                Service service = new Service
                {
                    Title = tbNazvanie.Text,
                    DurationInSeconds = dlitelnost,
                    Description = tbOpisanie.Text,
                    Discount = skidka,
                    Cost = stoimost,
                    MainImagePath = ""
                };
                viewModel.AddService(service);
            }
            else
            {
                MessageBox.Show("Данные введены не верно");
            }
        }
        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbDlitelnost.Text, out int dlitelnost)
                && double.TryParse(tbSkidka.Text, out double skidka)
                && decimal.TryParse(tbStoimost.Text, out decimal stoimost)
            )
            {
                Service service = new Service
                {
                    ID = Convert.ToInt32(tbId.Text),
                    Title = tbNazvanie.Text,
                    DurationInSeconds = dlitelnost,
                    Description = tbOpisanie.Text,
                    Discount = skidka,
                    Cost = stoimost,
                    MainImagePath = ""
                };
                viewModel.ChangeService(service);
            }
            else
            {
                MessageBox.Show("Данные введены не верно");
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }
    }
}
