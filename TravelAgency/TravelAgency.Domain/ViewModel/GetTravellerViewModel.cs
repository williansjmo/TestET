namespace TravelAgency.Domain.ViewModel
{
    using System;
    using TravelAgency.Domain.Entities;

    public class GetTravellerViewModel: BaseEntity
    {
        public Guid PassengerId { get; set; }
        public double IdentityCard { get; set; }
        public string Name { get; set; }

        public Guid TravelId { get; set; }
        public string TravelCode { get; set; }
        public double NumberOfSeats { get; set; }
        public string Destination { get; set; }
        public string PlaceOfOrigin { get; set; }
        public decimal Price { get; set; }
    }
}
