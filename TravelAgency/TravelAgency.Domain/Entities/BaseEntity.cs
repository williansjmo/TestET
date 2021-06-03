namespace TravelAgency.Domain.Entities
{
    using System;

    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

    }
}
