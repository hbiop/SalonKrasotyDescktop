using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.Entities.Dtos;
using SalonKrasotyDescktop.Mappers.Realizations;
using SalonKrasotyDescktop.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.ViewModels.Realizations
{
    public class ClientViewModel : IClientViewModel, INotifyPropertyChanged
    {
        private List<ClientDto> _clients = new List<ClientDto>();
        private SalonKrasotyEntities salonKrasotyEntities = new SalonKrasotyEntities();
        private ClientMapper clientMapper;
        public List<ClientDto> clients
        {
            get => _clients;
            set
            {
                _clients = value;
                OnPropertyChanged();
            }
        }
        public ClientViewModel()
        {
            salonKrasotyEntities = new SalonKrasotyEntities();
            clientMapper = new ClientMapper();
            GetClients();
        }
        public void GetClients()
        {
            _clients = clientMapper.MapToDtos(salonKrasotyEntities.Client.ToList());
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
    }
}
