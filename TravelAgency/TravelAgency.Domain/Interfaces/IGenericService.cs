
namespace TravelAgency.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TravelAgency.Domain.Entities;


    public interface IGenericService
    {
        Task<bool> AddAsync<T>(T entity);
        Task<bool> UpdateAsync<T>(T entity);
        Task<bool> DeleteAsync(Guid Id);
        Task<List<T>> GetAllAsync<T>();
        Task<T> GetAsync<T>(Guid Id);
    }
}
