namespace TravelAgency.Domain.Entities
{
    using System.Collections.Generic;


    //Viajes
    public class Travel : BaseEntity
    {
        public string TravelCode { get; set; }
        public double NumberOfSeats { get; set; }
        public string Destination { get; set; }
        public string PlaceOfOrigin { get; set; }
        public decimal Price { get; set; }

        public ICollection<Travellers> Travellers { get; set; }
    }
}
