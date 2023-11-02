using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data;
using MovieRentalAPI.Main.Data.Services;

namespace MovieRentalAPI.Main.Repositories
{
    public class CostumersRepository
    {
        private readonly IDataService<Costumer> dataService = new GenericDataService<Costumer>(new ApplicationDbContextFactory(null));

        public async Task<List<Costumer>> GetAllCostumer()
        {
            var movieList = await Task.WhenAll(dataService.Getall());
            List<Costumer> result = new List<Costumer>();
            foreach (var movie in movieList)
            {
                var movielisting = movie.ToList();
                result = movielisting;
            }
            return result;
        }

        public async Task<Costumer> GetCostumerById(Guid id)
        {
            return await dataService.Get(id);
        }
        public async Task<int> AddMovie(string Name, string Email, string Phone, bool isActive)
        {
            try
            {
                await dataService.Create(new Costumer
                {
                    Id = new Guid(),
                    Name = Name,
                    Email = Email,
                    Phone = Phone,
                    isActive = isActive
                });
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> DeleteCostumer(Guid id)
        {
            try
            {
                await dataService.Delete(id);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> UpdateCostumer(Costumer costumer)
        {
            try
            {
                await dataService.Update(costumer);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
