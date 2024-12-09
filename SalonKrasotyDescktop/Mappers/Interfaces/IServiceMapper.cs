using SalonKrasotyDescktop.entities;
using SalonKrasotyDescktop.entities.Dtos;
using SalonKrasotyDescktop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.Mappers.Interfaces
{
    public interface IServiceMapper
    {
        List<ServiceDto> MapToDtos(List<Service> service);
        ServiceDto MapToDto(Service service);
    }
}
