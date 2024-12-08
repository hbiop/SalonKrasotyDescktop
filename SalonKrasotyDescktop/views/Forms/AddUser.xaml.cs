using SalonKrasotyDescktop.entities;
using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.ViewModels;
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
        MainViewModel viewModel;
        public AddUser(MainViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }
        ServiceDto service;
        public AddUser(MainViewModel viewModel, ServiceDto service)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.service = service;
            tbNazvanie.Text = service.Title;
            tbDlitelnost.Text = service.Time.ToString();
            tbOpisanie.Text = service.Description;
            tbSkidka.Text = service.Discount.ToString();
            tbStoimost.Text = service.NewCost.ToString();
        }
    }
}
