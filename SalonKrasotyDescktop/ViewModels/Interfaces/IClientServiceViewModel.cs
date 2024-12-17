using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.ViewModels.Interfaces
{
    public interface IClientServiceViewModel
    {
        List<ClientServiceDto> clientServiceDtos { get; set; }
        void AddClientService(ClientService clientService);
        void GetClientService();
    }
}
