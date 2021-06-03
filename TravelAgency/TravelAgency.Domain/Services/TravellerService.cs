namespace TravelAgency.Domain.Services
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TravelAgency.Domain.Entities;
    using TravelAgency.Domain.Interfaces;
    using TravelAgency.Domain.ViewModel;

    public class TravellerService : IGenericService
    {
        private readonly IAsyncRepository<Travellers> repository;

        public TravellerService(IAsyncRepository<Travellers> repository)
        {
            this.repository = repository;
        }
        public async Task<List<T>> GetAllAsync<T>()
        {
            var entity = await repository.Include(t=> t.Travel,p=> p.Passenger).ToListAsync();
            var model = entity.Select(s=> new ListTravellerViewModel() 
            { 
                Id = s.Id, 
                Destination = s.Travel.Destination, 
                Name = s.Passenger.Name 
            }).ToList();

            return model as List<T>;
        }
        

        public async Task<T> GetAsync<T>(Guid Id)
        {
            var entity = await repository.Include(t=> t.Travel,p=> p.Passenger).ToListAsync();
            var model = entity.Where(w=> w.Id == Id).Select(s => new GetTravellerViewModel()
            {
                Id = s.Id,
                PassengerId = s.PassengerId,
                IdentityCard = s.Passenger.IdentityCard,
                Name = s.Passenger.Name,
                TravelId = s.TravelId,
                NumberOfSeats = s.Travel.NumberOfSeats,
                Destination = s.Travel.Destination,
                PlaceOfOrigin = s.Travel.PlaceOfOrigin,
                Price = s.Travel.Price,
                TravelCode = s.Travel.TravelCode
            }).FirstOrDefault();

            return await Task.FromResult((T)Convert.ChangeType(model, typeof(T)));
        }

        public async Task<bool> AddAsync<T>(T entity)
        {
            try
            {
                await repository.AddAsync(entity as Travellers);
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
                var entity = await repository.GetByIdAsync(Id);
                await repository.DeleteAsync(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public async Task<bool> UpdateAsync<T>(T entity)
        {
            try
            {
                var e = entity as Travellers;
                if (await repository.AnyExpressionAsync(t => t.PassengerId == e.PassengerId && t.TravelId == e.TravelId))
                    return false;

                await repository.UpdateAsync(e);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
