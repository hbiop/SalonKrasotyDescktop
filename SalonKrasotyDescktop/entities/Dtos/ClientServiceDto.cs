using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.Entities.Dtos
{
    public class ClientServiceDto
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic {  get; set; }
        public string Email { get; set; }
        public string Phone {  get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string TimeToEnd => (DateTime.Now - DateOfRegistration).ToString("hh\\:mm\\:ss");
        public bool IsUrgent => (DateTime.Now - DateOfRegistration).Hours < 1 ? true : false;
    }
}
