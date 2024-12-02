using SalonKrasotyDescktop.entities;
using SalonKrasotyDescktop.entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SalonKrasotyDescktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public MainViewModel(SalonKrasotyEntities salon)
        {
            _salon = salon;
            Init();
            services = services.OrderBy(s => s.NewCost).ToList();
        }
        public void Init()
        {
            services = _salon.Service.Select(service => new ServiceDto
            {
                PicPath = "images/Услуги салона красоты/none.jpg",
                Title = service.Title,
                Cost = service.Cost,
                Time = service.DurationInSeconds / 60,
                Discount = service.Discount ?? 0,
                Description = service.Description ?? "",
            }).ToList();
            foreach (var s in services)
            {
                s.NewCost = s.Discount == 0
                           ? s.Cost
                           : s.Cost - (s.Cost / 100 * (decimal)s.Discount);
            }
        }
        //Admin
        private static readonly string AdminCode = "0000";
        private bool _isAdmin;
        public bool isAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }
        public void IsAdmin(string input)
        {
            isAdmin = AdminCode == input;
        }
        //services
        private List<ServiceDto> _services = new List<ServiceDto>();
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
        
        public void GetData(int sortType, int filterType, string searchWord)
        {
            Init();
            countAllRecords = services.Count;
            Sort(sortType);
            FilterDiscount(filterType);
            Search(searchWord);
            countVivodRecords = services.Count;
        }
        public void Search(string searchWord)
        {
            services = services.Where(s => s.Title.Contains(searchWord) || s.Description.Contains(searchWord)).ToList();
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
    }
}