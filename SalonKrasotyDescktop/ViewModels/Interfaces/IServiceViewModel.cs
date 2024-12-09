using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.ViewModels.Interfaces
{
    public interface IServiceViewModel
    {
        void DeleteService(int id);
        void GetServices(int sortType, int filterType, string searchWord);
        void AddService(Service service);
        void ChangeService(Service service);
        List<ServiceDto> services { get; set; }
        int countAllRecords { get; set; }
        int countVivodRecords { get; set; }

    }
}
