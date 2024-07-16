using Microsoft.AspNetCore.Mvc;
using Autotech.Core.Models;
using Autotech.BusinessLayer.Repositories;
using Autotech.BusinessLayer.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Autotech.Main.Controllers.v1
{
    [Route("api/v1/Accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountsRepository _repository = new AccountsRepository();
        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<List<Accounts>> Get()
        {
            return await _repository.GetAllAccount();
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<Accounts> Get(Guid id)
        {
            return await _repository.GetAccountById(id);
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AccountRequestDto model)
        {
            try
            {
                await _repository.AddAccount(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Accounts costumer)
        {
            try
            {
                await _repository.UpdateAccount(costumer);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE api/<AccountsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.DeleteAccount(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
