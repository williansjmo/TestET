namespace TravelAgency.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelAgency.Domain.Entities;
    using TravelAgency.Domain.Interfaces;

    class PassengerService
    {
        private readonly IAsyncRepository<Passenger> repository;

        public PassengerService(IAsyncRepository<Passenger> repository)
        {
            this.repository = repository;
        }
    }
}
