using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.ViewModels.Interfaces
{
    public interface IClientViewModel
    {
        void GetClients();
        List<ClientDto> clients { get; set; }

    }
}
