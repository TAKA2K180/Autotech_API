using Microsoft.EntityFrameworkCore.Internal;
using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data;
using MovieRentalAPI.Main.Data.Services;

namespace MovieRentalAPI.Main.Repositories
{
    public class MoviesRepository
    {
        private readonly IDataService<Movie> dataService = new GenericDataService<Movie>(new ApplicationDbContextFactory(null));

        public async Task<List<Movie>> GetAllMovies()
        {
            var movieList = await Task.WhenAll(dataService.Getall());
            List<Movie> result = new List<Movie>();
            foreach (var movie in movieList) 
            {
                var movielisting = movie.ToList();
                result = movielisting;
            }
            return result;
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await dataService.Get(id);
        }

        public async Task<int> AddMovie(string Name, string Description, decimal Price, string Category)
        {
            try
            {
                await dataService.Create(new Movie
                {
                    Id = new Guid(),
                    Title = Name,
                    Description = Description,
                    Price = Price,
                    Category = Category,
                    DateCreated = DateTime.Now
                });
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> DeleteMovie(Guid id)
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

        public async Task<int> UpdateMovie(Movie movie)
        {
            try
            {
                await dataService.Update(movie);
                return 0;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
