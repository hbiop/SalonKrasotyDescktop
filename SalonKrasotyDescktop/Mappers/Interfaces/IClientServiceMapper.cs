using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.Mappers.Interfaces
{
    public interface IClientServiceMapper
    {
        List<ClientServiceDto> MapToDtos(List<ClientService> service);
        ClientServiceDto MapToDto(ClientService service);
    }
}
