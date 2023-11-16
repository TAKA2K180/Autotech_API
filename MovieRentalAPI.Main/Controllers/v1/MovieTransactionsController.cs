using Microsoft.AspNetCore.Mvc;
using MovieRental.Core.Models;
using MovieRentalAPI.Main.Data.DTO;
using MovieRentalAPI.Main.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRentalAPI.Main.Controllers.v1
{
    [Route("api/v1/Transactions")]
    [ApiController]
    public class MovieTransactionsController : ControllerBase
    {
        private readonly MovieTransactionsRepository _repository = new MovieTransactionsRepository();

        // GET: api/<MovieTransactionsController>
        [HttpGet]
        public async Task<List<MovieTransaction>> Get()
        {
            return await _repository.GetAllTransactions();
        }

        // GET api/<MovieTransactionsController>/5
        [HttpGet("{id}")]
        public async Task<MovieTransaction> Get(Guid id)
        {
            return await _repository.GetTransactionById(id);
        }

        // POST api/<MovieTransactionsController>
        [HttpPost]
        public async Task<IActionResult> Post(Guid movieId, Guid customerId, decimal totalAmount, bool isReturned)
        {
            try
            {
                await _repository.AddTransaction(Guid.NewGuid(), movieId,customerId,totalAmount,isReturned);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<MovieTransactionsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(MovieTransaction movieTransaction)
        {
            try
            {
                await _repository.UpdateTransaction(movieTransaction);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<MovieTransactionsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteTransaction(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
