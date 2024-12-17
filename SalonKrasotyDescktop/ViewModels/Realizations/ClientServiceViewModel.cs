using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.Entities.Dtos;
using SalonKrasotyDescktop.Mappers.Interfaces;
using SalonKrasotyDescktop.Mappers.Realizations;
using SalonKrasotyDescktop.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace SalonKrasotyDescktop.ViewModels.Realizations
{
    public class ClientServiceViewModel : IClientServiceViewModel, INotifyPropertyChanged
    {
        SalonKrasotyEntities salonKrasotyEntities;
        IClientServiceMapper clientServiceMapper;
        public ClientServiceViewModel()
        {
            salonKrasotyEntities = new SalonKrasotyEntities();
            clientServiceMapper = new ClientServiceMapper();
            GetClientService();
        }
        private List<ClientServiceDto> _clientService = new List<ClientServiceDto>();
        public List<ClientServiceDto> clientServiceDtos 
        { 
            get =>  _clientService; 
            set
            {
                _clientService = value;
                OnPropertyChanged();
            }
        }
        private DispatcherTimer _timer;
        public void AddClientService(ClientService clientService)
        {
            try
            {
                salonKrasotyEntities.ClientService.Add(clientService);
                MessageBox.Show("Клиент был записан");
            }
            catch
            {
                MessageBox.Show("Произошла непредвиденая ошибка");
            }
        }
        public void StartTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(30);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            GetClientService();
        }

        public void GetClientService()
        {
            var endDate = DateTime.Now.AddDays(2);
            var services = clientServiceMapper.MapToDtos(salonKrasotyEntities.ClientService
                .Where(a => a.StartTime >= DateTime.Now && a.StartTime <= endDate)
                .OrderBy(a => a.StartTime)
                .ToList());

            clientServiceDtos = services; 
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
