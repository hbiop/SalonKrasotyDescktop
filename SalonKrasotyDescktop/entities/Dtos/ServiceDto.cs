using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalonKrasotyDescktop.entities.Dtos
{
    public class ServiceDto
    {
        public string PicPath { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public decimal NewCost { get; set; }
        public int Time { get; set; }
        public double Discount { get; set; }
        public string Description {  get; set; }
    }
}
