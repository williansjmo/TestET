namespace TravelAgency.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    //Viajeros
    public class Travellers : BaseEntity
    {
        public Guid PassengerId { get; set; }
        public Guid TravelId { get; set; }

        public Passenger Passenger { get; set; }
        public Travel Travel { get; set; }
    }
}
