using Microsoft.AspNetCore.Mvc;
using Autotech.Core.Models;
using Autotech.Main.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autotech.Main.Controllers.v1
{
    [Route("api/v1/Costumers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomersRepository _repository = new CustomersRepository();
        // GET: api/<CostumersController>
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await _repository.GetAllCustomer();
        }

        // GET api/<CostumersController>/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(Guid id)
        {
            return await _repository.GetCustomerById(id);
        }

        // POST api/<CostumersController>
        [HttpPost]
        public async Task<IActionResult> Post(string name, string email, string phone, bool isActive)
        {
            try
            {
                await _repository.AddCustomer(Guid.NewGuid(), name, email, phone, isActive);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT api/<CostumersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Customer costumer)
        {
            try
            {
                await _repository.UpdateCustomer(costumer);
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
                await _repository.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
