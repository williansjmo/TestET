namespace TravelAgency.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using TravelAgency.Domain.Entities;

    public class TravelAgencyDbContext : DbContext
    {
        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<Travel> Travel { get; set; }
        public DbSet<Travellers> Travellers { get; set; }

        public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> dbContext) : base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
