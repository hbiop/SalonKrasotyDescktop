using SalonKrasotyDescktop.ViewModels.Interfaces;
using SalonKrasotyDescktop.ViewModels.Realizations;
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

namespace SalonKrasotyDescktop.Views.Forms
{
    /// <summary>
    /// Логика взаимодействия для ViewRegistrations.xaml
    /// </summary>
    public partial class ViewRegistrations : Window
    {
        private ClientServiceViewModel clientServiceViewModel;
        public ViewRegistrations()
        {
            InitializeComponent();
            clientServiceViewModel = new ClientServiceViewModel();
            clientServiceViewModel.StartTimer();
            DataGridClientService.DataContext = clientServiceViewModel;
        }
    }
}
