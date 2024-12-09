using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.entities;
using SalonKrasotyDescktop.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SalonKrasotyDescktop.Mappers.Interfaces;
using SalonKrasotyDescktop.Mappers.Realizations;
using SalonKrasotyDescktop.Entities;

namespace SalonKrasotyDescktop.ViewModels.Realizations
{
    public class ServiceViewModel : IServiceViewModel, INotifyPropertyChanged
    {
        private List<ServiceDto> _services = new List<ServiceDto>();
        private IServiceMapper serviceMapper = new ServiceMapper();
        SalonKrasotyEntities _salon;
        public List<ServiceDto> services
        {
            get => _services;
            set
            {
                _services = value;
                OnPropertyChanged();
            }
        }
        private int _countAllRecords;
        public int countAllRecords
        {
            get => _countAllRecords;
            set
            {
                _countAllRecords = value;
                OnPropertyChanged();
            }
        }
        private int _countVivodRecords;
        public int countVivodRecords
        {
            get => _countVivodRecords;
            set
            {
                _countVivodRecords = value;
                OnPropertyChanged();
            }
        }
        public ServiceViewModel(SalonKrasotyEntities salon)
        {
            _salon = salon;
            InitData();
            services = services.OrderBy(s => s.NewCost).ToList();
        }

        public void InitData()
        {
            services = serviceMapper.MapToDtos(_salon.Service.ToList());
        }

        public void DeleteService(int id)
        {
            int count = _salon.ClientService.Where(cs => cs.Service.ID == id).Count();
            if (count > 0)
            {
                MessageBox.Show("Вы не можете удалить эту услугу так как есть записи");
            }
            else
            {
                foreach (var sp in _salon.ServicePhoto.Where(sp2 => sp2.ServiceID == id))
                {
                    _salon.ServicePhoto.Remove(sp);
                }
                _salon.Service.Remove(_salon.Service.Where(s => s.ID == id).FirstOrDefault());
                _salon.SaveChanges();
            }
        }

        public void GetServices(int sortType, int filterType, string searchWord)
        {
            InitData();
            countAllRecords = services.Count;
            Sort(sortType);
            FilterDiscount(filterType);
            Search(searchWord);
            countVivodRecords = services.Count;
        }

        public void Search(string searchWord)
        {
            services = services.Where(s => s.Title.ToLower().Contains(searchWord.ToLower()) || s.Description.ToLower().Contains(searchWord.ToLower())).ToList();
        }

        public void Sort(int sortType)
        {
            switch (sortType)
            {
                case 0:
                    services = services.OrderBy(s => s.NewCost).ToList();
                    break;
                case 1:
                    services = services.OrderByDescending(s => s.NewCost).ToList();
                    break;
                default:
                    services = services.OrderBy(s => s.NewCost).ToList();
                    break;
            }

        }

        public void FilterDiscount(int filterType)
        {
            switch (filterType)
            {
                case 0:
                    services = services;
                    break;
                case 1:
                    services = services.Where(s => s.Discount >= 0 && s.Discount < 5).ToList();
                    break;
                case 2:
                    services = services.Where(s => s.Discount >= 5 && s.Discount < 15).ToList();
                    break;
                case 3:
                    services = services.Where(s => s.Discount >= 15 && s.Discount < 30).ToList();
                    break;
                case 4:
                    services = services.Where(s => s.Discount >= 30 && s.Discount < 70).ToList();
                    break;
                case 5:
                    services = services.Where(s => s.Discount >= 70 && s.Discount < 100).ToList();
                    break;
                default:
                    services = services;
                    break;
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
    }
}
