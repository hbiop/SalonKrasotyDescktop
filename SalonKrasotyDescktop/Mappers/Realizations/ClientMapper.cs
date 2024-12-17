using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.Entities.Dtos;
using SalonKrasotyDescktop.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.Mappers.Realizations
{
    public class ClientMapper : IClientMapper
    {
        public ClientDto MapToDto(Client service)
        {
            return new ClientDto
            {
                Id = service.ID,
                Fio = service.FirstName + " " + service.LastName + " " + service.Patronymic,
            };
        }

        public List<ClientDto> MapToDtos(List<Client> service)
        {
            return service.Select(s => MapToDto(s)).ToList();
        }
    }
}
