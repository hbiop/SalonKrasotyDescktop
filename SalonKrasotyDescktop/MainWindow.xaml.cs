using SalonKrasotyDescktop.entities;
using SalonKrasotyDescktop.entities.Dtos;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SalonKrasotyDescktop.ViewModels;
using SalonKrasotyDescktop.ViewModels.Realizations;
using SalonKrasotyDescktop.views.Forms;
using SalonKrasotyDescktop.ViewModels.Interfaces;
using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.Views.Forms;

namespace SalonKrasotyDescktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SalonKrasotyEntities salon = new SalonKrasotyEntities();
        private static int Sort = 0;
        private static int Filter = 0;
        private static string Search = "";
        private IAdminViewModel _adminViewModel = new AdminViewModel();
        private IServiceViewModel _serviceViewModel = new ServiceViewModel(salon);
        public MainWindow()
        {
            InitializeComponent();
            lvServices.DataContext = _serviceViewModel;
            stPanel.DataContext = _serviceViewModel;
            DataContext = _adminViewModel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            EnterAdminCode enterAdminCode = new EnterAdminCode(_adminViewModel);
            enterAdminCode.ShowDialog();
        }

        private void cmbSortStoimost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort = cmbSortStoimost.SelectedIndex;
            _serviceViewModel.GetServices(Sort, Filter, Search);
        }

        private void cmbFilterDisount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter = cmbFilterDisount.SelectedIndex;
            _serviceViewModel.GetServices(Sort, Filter, Search);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search = tbSearch.Text;
            _serviceViewModel.GetServices(Sort, Filter, Search);
        }

        private void ButtonDelete(object sender, RoutedEventArgs e)
        {
            if(sender != null && sender is Button)
            {
                Button btn = (Button)sender;
                if(btn.Tag != null && Int32.TryParse(Convert.ToString(btn.Tag), out int id))
                {
                    _serviceViewModel.DeleteService(id);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser(_serviceViewModel);
            this.Close();
            addUser.ShowDialog();
            
        }

        private void ButtonChange(object sender, RoutedEventArgs e)
        {
            if (sender != null && sender is Button)
            {
                Button btn = (Button)sender;
                if (btn.Tag != null && Int32.TryParse(Convert.ToString(btn.Tag), out int id))
                {
                    AddUser addUser = new AddUser(_serviceViewModel, _serviceViewModel.services.Where(s => s.Id == id).FirstOrDefault());
                    this.Close();
                    addUser.ShowDialog();
                }
            }
        }

        private void btnAddRegistration_Click(object sender, RoutedEventArgs e)
        {
            AddRegistration addRegistration = new AddRegistration();
            addRegistration.Show();
        }
    }
}
