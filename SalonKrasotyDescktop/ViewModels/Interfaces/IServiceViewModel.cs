using SalonKrasotyDescktop.entities.Dtos;
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
        List<ServiceDto> services { get; set; }
        int countAllRecords { get; set; }
        int countVivodRecords { get; set; }
    }
}
