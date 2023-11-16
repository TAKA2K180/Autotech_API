using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieRental.Core.Services;
using MovieRental.Core.Models;
using MovieRentalAPI.Main.Data.Services;
using MovieRentalAPI.Main.Data;
using MovieRentalAPI.Main.Repositories;

namespace MovieRental.Test.Repositories
{
    public class MovieRepository
    {
        private readonly MoviesRepository _moviesRepository = new MoviesRepository();
        [Fact]
        public async Task GetAllMovies_ShouldReturnListOfMovies()
        {

            // Act
            var result = await _moviesRepository.GetAllMovies();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<Movie>>(result);
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task GetMovieById_ShouldReturnCorrectMovie()
        {
            // Arrange - Assuming a movie with a known ID exists in the test database
            Guid existingMovieId = Guid.Parse("E430487D-C6BE-4332-5046-08DBE4B9B8A3");

            // Act
            var result = await _moviesRepository.GetMovieById(existingMovieId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Movie>(result);
            Assert.Equal(existingMovieId, result.Id);
        }

        [Fact]
        public async Task AddMovie_ShouldCreateNewMovie()
        {
            // Arrange - Input parameters for the new movie
            var title = "Test Movie";
            var description = "Description for the test movie.";
            var price = 9.99m;
            var category = "Test Category";
            Guid guid = Guid.NewGuid();

            // Act
            await _moviesRepository.AddMovie(guid, title, description, price, category);

            // Assert - Check if the movie was added by querying the database or checking a count
            var addedMovie = await _moviesRepository.GetMovieById(guid);
            Assert.NotNull(addedMovie);
            Assert.Equal(title, addedMovie.Title);
            Assert.Equal(description, addedMovie.Description);
            Assert.Equal(price, addedMovie.Price);
            Assert.Equal(category, addedMovie.Category);
        }

        [Fact]
        public async Task DeleteMovie_ShouldRemoveMovie()
        {
            // Arrange - Assuming a movie with a known ID exists in the test database
            Guid existingMovieId = Guid.Parse("BB26A078-C712-4FC3-8FF8-A3FA8272624B");

            // Act
            await _moviesRepository.DeleteMovie(existingMovieId);

            // Assert - Check if the movie was deleted by querying the database or checking a count
            var deletedMovie = await _moviesRepository.GetMovieById(existingMovieId);
            Assert.Null(deletedMovie);
        }

        [Fact]
        public async Task UpdateMovie_ShouldModifyMovieDetails()
        {
            // Arrange - Assuming a movie with a known ID exists in the test database
            var existingMovieId = Guid.Parse("8F537A43-F461-4C1A-10D2-08DBE585D76A");
            var updatedMovie = new Movie
            {
                Id = existingMovieId,
                Title = "Updated Title",
                Description = "Updated Description",
                Price = 14.99m,
                Category = "Updated Category",
                TransactionDate = DateTime.Now
            };

            // Act
            await _moviesRepository.UpdateMovie(updatedMovie);

            // Assert - Check if the movie was updated by querying the database or checking details
            var modifiedMovie = await _moviesRepository.GetMovieById(existingMovieId);
            Assert.NotNull(modifiedMovie);
            Assert.Equal(updatedMovie.Title, modifiedMovie.Title);
            Assert.Equal(updatedMovie.Description, modifiedMovie.Description);
            Assert.Equal(updatedMovie.Price, modifiedMovie.Price);
            Assert.Equal(updatedMovie.Category, modifiedMovie.Category);
        }
    }
}
