using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.Domain.Entities
{
    //Viajes
    public class Travel : BaseEntity
    {
        public string TravelCode { get; set; }
        public double NumberOfSeats { get; set; }
        public string Destination { get; set; }
        public string PlaceOfOrigin { get; set; }
        public decimal Price { get; set; }
    }
}
