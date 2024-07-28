using Autotech.BusinessLayer.Data.DTO;
using Autotech.BusinessLayer.Repositories;
using Autotech.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Autotech.Main.Controllers.v1
{
    [Route("api/v1/Agents")]
    [ApiController]
    public class AgentsController : Controller
    {
        private readonly AgentsRepository _repository = new AgentsRepository();
        // GET: api/<AccountsController>
        [HttpGet]
        public async Task<List<Agents>> Get()
        {
            return await _repository.GetAllAgent();
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public async Task<Agents> Get(Guid id)
        {
            return await _repository.GetAgentById(id);
        }

        // POST api/<AccountsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AgentRequestDTO model)
        {
            try
            {
                await _repository.AddAgent(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Agents agents)
        {
            try
            {
                await _repository.UpdateAgent(agents);
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
                await _repository.DeleteAgent(id);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
