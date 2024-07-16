using Autotech.BusinessLayer.Data.DTO;
using Autotech.BusinessLayer.Repositories;
using Autotech.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autotech.Main.Controllers.v1
{
    [Route("api/v1/Items")]
    [ApiController]
    public class ItemsController : Controller
    {
        private readonly ItemsRepository _repository = new ItemsRepository();
        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<List<Items>> Get()
        {
            return await _repository.GetAllItems();
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<Items> Get(Guid id)
        {
            return await _repository.GetItemById(id);
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemRequestDto model)
        {
            try
            {
                await _repository.AddItem(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Items items)
        {
            try
            {
                await _repository.UpdateItem(items);
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
                await _repository.DeleteItem(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
