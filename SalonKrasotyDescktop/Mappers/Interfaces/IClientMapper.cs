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
    public interface IClientMapper
    {
        List<ClientDto> MapToDtos(List<Client> service);
        ClientDto MapToDto(Client service);
    }
}
