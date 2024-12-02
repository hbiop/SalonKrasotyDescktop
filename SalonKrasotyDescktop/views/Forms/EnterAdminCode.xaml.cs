using System.Windows;
using SalonKrasotyDescktop.ViewModels;

namespace SalonKrasotyDescktop.views.Forms
{
    public partial class EnterAdminCode : Window
    {
        MainViewModel viewModel;
        public EnterAdminCode(MainViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            viewModel.IsAdmin(TbAdminCode.Text);
        }
    }
}