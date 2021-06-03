namespace TravelAgency.Domain.ViewModel
{
    using TravelAgency.Domain.Entities;


    public class ListTravellerViewModel : BaseEntity
    {

        public string Destination { get; set; }
        public string Name { get; set; }
    }
}
