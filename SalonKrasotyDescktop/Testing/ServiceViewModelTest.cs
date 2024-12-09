using SalonKrasotyDescktop.Entities;
using SalonKrasotyDescktop.ViewModels.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace SalonKrasotyDescktop.Testing
{
    public class ServiceViewModelTest
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            SalonKrasotyEntities salon = new SalonKrasotyEntities();
            ServiceViewModel serviceViewModel = new ServiceViewModel(salon);
            Service service = new Service
            {
                Title = "Название",
                DurationInSeconds = 35000,
                Description = "Описание",
                Discount = 23,
                Cost = 255,
                MainImagePath = ""
            };
            serviceViewModel.AddService(service);
            Assert.Equal("aa", "aa");
        }
    }
}
