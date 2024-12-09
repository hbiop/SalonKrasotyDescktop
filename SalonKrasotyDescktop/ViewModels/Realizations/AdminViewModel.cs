using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SalonKrasotyDescktop.ViewModels.Interfaces;

namespace SalonKrasotyDescktop.ViewModels.Realizations
{
    public class AdminViewModel : IAdminViewModel, INotifyPropertyChanged
    {
        private static readonly string AdminCode = "0000";
        private bool _isAdmin;
        
        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void CheckIsAdmin(string input)
        {
            IsAdmin = AdminCode == input;
        }
    }
}