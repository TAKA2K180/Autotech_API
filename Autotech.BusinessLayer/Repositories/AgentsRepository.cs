using Autotech.BusinessLayer.Data.Services;
using Autotech.BusinessLayer.Data;
using Autotech.Core.Models;
using Autotech.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autotech.BusinessLayer.Data.DTO;

namespace Autotech.BusinessLayer.Repositories
{
    public class AgentsRepository
    {
        #region Private Variables
        private readonly IDataService<Agents> agentsData = new GenericDataService<Agents>(new ApplicationDbContextFactory(null));
        #endregion
        #region Functions

        public async Task<List<Agents>> GetAllAgent()
        {
            var agentList = await Task.WhenAll(agentsData.GetAll());
            List<Agents> result = new List<Agents>();
            result = agentList.Select(a => a.ToList()).LastOrDefault() ?? new List<Agents>();
            return result;
        }

        public async Task<Agents> GetAgentById(Guid id)
        {
            return await agentsData.GetById(id);
        }
        public async Task AddAgent(AgentRequestDTO model)
        {
            var newHeaderId = Guid.NewGuid();
            await agentsData.Create(new Agents
            {
                Id = newHeaderId,
                Username = model.Username,
                Password = model.Password,
                AgentName = model.AgentName,
                AgentAddress = model.AgentAddress,
                AgentContactNumber = model.AgentContactNumber,
                AgentRole = model.AgentRole,
                DateCreated = DateTime.Now,
                DateLastLogin = null
            });
        }

        public async Task DeleteAgent(Guid id)
        {
            await agentsData.Delete(id);
        }

        public async Task UpdateAgent(Agents agent)
        {
            await agentsData.Update(agent);
        }
        #endregion
    }
}
