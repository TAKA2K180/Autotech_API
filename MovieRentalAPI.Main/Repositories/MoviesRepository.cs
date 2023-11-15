using Microsoft.EntityFrameworkCore.Internal;
using MovieRental.Core.Models;
using MovieRental.Core.Services;
using MovieRentalAPI.Main.Data;
using MovieRentalAPI.Main.Data.Services;
using System.Linq;

namespace MovieRentalAPI.Main.Repositories
{
    public class MoviesRepository
    {
        private readonly IDataService<Movie> dataService = new GenericDataService<Movie>(new ApplicationDbContextFactory(null));

        public async Task<List<Movie>> GetAllMovies()
        {
            var movieList = await Task.WhenAll(dataService.GetAll());
            List<Movie> result = new List<Movie>();
            result = movieList.Select(movie => movie.ToList()).LastOrDefault() ?? new List<Movie>();
            return result;
        }

        public async Task<Movie> GetMovieById(Guid id)
        {
            return await dataService.GetById(id);
        }

        public async Task AddMovie(string Title, string Description, decimal Price, string Category)
        {
            await dataService.Create(new Movie
            {
                Id = new Guid(),
                Title = Title,
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
