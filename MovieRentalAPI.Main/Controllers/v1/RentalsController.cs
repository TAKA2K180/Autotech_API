using Microsoft.AspNetCore.Mvc;
using MovieRental.Core.Models;
using MovieRentalAPI.Main.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRentalAPI.Main.Controllers.v1
{
    [Route("api/v1/Rentals")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        #region Private Variables
        private readonly RentalsRepository _rentalsRepository = new RentalsRepository();
        #endregion

        // GET: api/<RentalsController>
        [HttpGet]
        public Task<List<Rentals>> Get()
        {
            return _rentalsRepository.GetAllRentals();
        }

        // GET api/<RentalsController>/5
        [HttpGet("{id}")]
        public Task<Rentals> Get(Guid id)
        {
            return _rentalsRepository.GetRentalById(id);
        }

        // POST api/<RentalsController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid customerId, Guid movieId, Guid transactionId)
        {
            try
            {
                await _rentalsRepository.AddRental(Guid.NewGuid(), customerId, movieId, transactionId);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        // PUT api/<RentalsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Rentals rental)
        {
            try
            {
                await _rentalsRepository.UpdateRental(rental);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        // DELETE api/<RentalsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _rentalsRepository.DeleteRental(id);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }
    }
}
