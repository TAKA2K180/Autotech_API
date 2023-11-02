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

        public async Task AddMovie(string Name, string Description, decimal Price, string Category)
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
        }

        public async Task DeleteMovie(Guid id)
        {
            await dataService.Delete(id);
        }

        public async Task UpdateMovie(Movie movie)
        {
            await dataService.Update(movie);
        }
    }
}
