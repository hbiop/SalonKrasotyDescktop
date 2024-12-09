using SalonKrasotyDescktop.entities;
using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.Mappers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.Mappers.Realizations
{
    internal class ServiceMapper : IServiceMapper
    {
        public List<ServiceDto> MapToDtos(List<Service> service)
        {
            return service.Select(s => MapToDto(s)).ToList();
        }

        public ServiceDto MapToDto(Service service)
        {
            return new ServiceDto
            {
                Id = service.ID,
                PicPath = "images/Услуги салона красоты/none.jpg",
                Title = service.Title,
                Cost = service.Cost,
                Time = service.DurationInSeconds / 60,
                Discount = service.Discount ?? 0,
                Description = service.Description ?? "",
            };
        }
    }
}
