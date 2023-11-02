using Microsoft.AspNetCore.Mvc;
using MovieRental.Core.Models;
using MovieRentalAPI.Main.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieRentalAPI.Main.Controllers.v1
{
    [Route("api/v1/Costumers")]
    [ApiController]
    public class CostumersController : ControllerBase
    {
        private readonly CostumersRepository _repository = new CostumersRepository();
        // GET: api/<CostumersController>
        [HttpGet]
        public async Task<List<Costumer>> Get()
        {
            return await _repository.GetAllCostumer();
        }

        // GET api/<CostumersController>/5
        [HttpGet("{id}")]
        public async Task<Costumer> Get(Guid id)
        {
            return await _repository.GetCostumerById(id);
        }

        // POST api/<CostumersController>
        [HttpPost]
        public async Task<IActionResult> Post(string name, string email, string phone, bool isActive)
        {
            try
            {
                await _repository.AddCostumer(name, email, phone, isActive);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<CostumersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Costumer costumer)
        {
            try
            {
                await _repository.UpdateCostumer(costumer);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<CostumersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteCostumer(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
