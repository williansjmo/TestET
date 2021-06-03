namespace TravelAgency.Domain.Services
{
    using System;
    using System.Collections.Generic;
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

        public async Task<List<T>> GetAllAsync<T>() => await repository.ListAllAsync() as List<T>;

        public async Task<T> GetAsync<T>(Guid Id) => await Task.FromResult((T)Convert.ChangeType(await repository.GetByIdAsync(Id), typeof(T)));

        public async Task<T> GetPassengerIdentityCard<T>(double IdentityCard) => await Task.FromResult((T)Convert.ChangeType(await repository.GetExpressionAsync(g => g.IdentityCard == IdentityCard), typeof(T)));

        public async Task<bool> AddAsync<T>(T entity)
        {
            try
            {
                await repository.AddAsync(entity as Passenger);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                var entity = await GetAsync<Passenger>(Id);
                await repository.DeleteAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync<T>(T entity)
        {
            try
            {
                await repository.UpdateAsync(entity as Passenger);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
