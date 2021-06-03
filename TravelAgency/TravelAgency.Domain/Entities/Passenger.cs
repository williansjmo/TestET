namespace TravelAgency.Domain.Entities
{
    //Pasajeros
    public class Passenger : BaseEntity
    {
        public double IdentityCard { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
    }
}
