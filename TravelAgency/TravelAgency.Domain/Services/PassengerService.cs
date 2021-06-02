namespace TravelAgency.Domain.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelAgency.Domain.Entities;
    using TravelAgency.Domain.Interfaces;

    public class PassengerService : IGenericService
    {
        private readonly IAsyncRepository<Passenger> repository;

        public PassengerService(IAsyncRepository<Passenger> repository)
        {
            this.repository = repository;
        }

        public async Task AddAsync<T>(T entity)=> await repository.AddAsync(entity as Passenger);

        public async Task DeleteAsync(Guid Id)
        {
            var entity = await GetAsync<Passenger>(Id);
            await repository.DeleteAsync(entity);
        }

        public async Task<List<T>> GetAllAsync<T>() => await repository.ListAllAsync() as List<T>;
        
        public async Task<T> GetAsync<T>(Guid Id) => await Task.FromResult((T)Convert.ChangeType(await repository.GetByIdAsync(Id), typeof(T)));

        public async Task UpdateAsync<T>(T entity) => await repository.AddAsync(entity as Passenger);

    }
}
