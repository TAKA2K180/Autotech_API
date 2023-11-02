using Microsoft.AspNetCore.Mvc;
using MovieRental.Core.Models;
using MovieRentalAPI.Main.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRentalAPI.Main.Controllers.v1
{
    [Route("api/v1/movies")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        #region Private Variables
        private readonly MoviesRepository _repository = new MoviesRepository();
        #endregion

        #region Web Methods
        // GET: api/<MoviesController>
        [HttpGet]
        public async Task<List<Movie>> Get()
        {
            return await _repository.GetAllMovies();
        }

        // GET api/<MoviesController>/5
        [HttpGet("{id}")]
        public async Task<Movie> Get(Guid id)
        {
            return await _repository.GetMovieById(id);
        }

        // POST api/<MoviesController>
        [HttpPost]
        public async Task<IActionResult> Post(string Name, string Description, decimal Price, string Category)
        {
            try
            {
                await _repository.AddMovie(Name, Description, Price, Category);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<MoviesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Movie movie)
        {
            try
            {
                await _repository.UpdateMovie(movie);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<MoviesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteMovie(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        } 
        #endregion
    }
}
