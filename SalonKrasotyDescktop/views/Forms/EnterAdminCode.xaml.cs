using System.Windows;
using SalonKrasotyDescktop.ViewModels;
using SalonKrasotyDescktop.ViewModels.Interfaces;

namespace SalonKrasotyDescktop.views.Forms
{
    public partial class EnterAdminCode : Window
    {
        IAdminViewModel viewModel;
        public EnterAdminCode(IAdminViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            viewModel.CheckIsAdmin(TbAdminCode.Text);
        }
    }
}