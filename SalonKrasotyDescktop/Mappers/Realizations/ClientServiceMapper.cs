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
    public class ClientServiceMapper : IClientServiceMapper
    {
        public ClientServiceDto MapToDto(ClientService service)
        {
            return new ClientServiceDto
            {
                Title = service.Service.Title,
                FirstName = service.Client.FirstName,
                LastName = service.Client.LastName,
                Patronymic = service.Client.Patronymic,
                Email = service.Client.Email,
                Phone = service.Client.Phone,
                DateOfRegistration = service.StartTime
            };
        }

        public List<ClientServiceDto> MapToDtos(List<ClientService> service)
        {
            return service.Select(s => MapToDto(s)).ToList();
        }
    }
}
