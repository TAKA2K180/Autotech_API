using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data;
using MovieRentalAPI.Main.Data.Services;
using System.Linq;

namespace MovieRentalAPI.Main.Repositories
{
    public class CostumersRepository
    {
        private readonly IDataService<Costumer> dataService = new GenericDataService<Costumer>(new ApplicationDbContextFactory(null));

        public async Task<List<Costumer>> GetAllCostumer()
        {
            var movieList = await Task.WhenAll(dataService.GetAll());
            List<Costumer> result = new List<Costumer>();
            result = movieList.Select(movie => movie.ToList()).LastOrDefault() ?? new List<Costumer>();
            return result;
        }

        public async Task<Costumer> GetCostumerById(Guid id)
        {
            return await dataService.GetById(id);
        }
        public async Task AddCostumer(string Name, string Email, string Phone, bool isActive)
        {
            await dataService.Create(new Costumer
            {
                Id = new Guid(),
                Name = Name,
                Email = Email,
                Phone = Phone,
                isActive = isActive
            });
        }

        public async Task DeleteCostumer(Guid id)
        {
            await dataService.Delete(id);
        }

        public async Task UpdateCostumer(Costumer costumer)
        {
            await dataService.Update(costumer);
        }
    }
}
