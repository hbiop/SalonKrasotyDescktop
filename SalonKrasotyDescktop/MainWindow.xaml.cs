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
using SalonKrasotyDescktop.views.Forms;

namespace SalonKrasotyDescktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SalonKrasotyEntities salon = new SalonKrasotyEntities();
        MainViewModel mainViewModel = new MainViewModel(salon);
        private static int Sort = 0;
        private static int Filter = 0;
        private static string Search = "";

        public MainWindow()
        {
            InitializeComponent();
            lvServices.DataContext = mainViewModel;
            stPanel.DataContext = mainViewModel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            EnterAdminCode enterAdminCode = new EnterAdminCode(mainViewModel);
            enterAdminCode.ShowDialog();
        }

        private void cmbSortStoimost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sort = cmbSortStoimost.SelectedIndex;
            mainViewModel.GetData(Sort, Filter, Search);
        }

        private void cmbFilterDisount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter = cmbFilterDisount.SelectedIndex;
            mainViewModel.GetData(Sort, Filter, Search);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search = tbSearch.Text;
            mainViewModel.GetData(Sort, Filter, Search);
        }
    }
}
