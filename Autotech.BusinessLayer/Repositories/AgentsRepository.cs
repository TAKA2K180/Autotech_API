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
using Autotech.Common.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Autotech.BusinessLayer.Repositories
{
    public class AgentsRepository
    {
        #region Private Variables
        private readonly IDataService<Agents> agentsData = new GenericDataService<Agents>(new ApplicationDbContextFactory(null));
        private readonly IDataService<Locations> locationData = new GenericDataService<Locations>(new ApplicationDbContextFactory(null));
        #endregion
        #region Functions

        public async Task<List<Agents>> GetAllAgent()
        {
            var agentList = (await agentsData.GetAll()).ToList();
            var locations = (await locationData.GetAll()).ToDictionary(loc => loc.Id);
            foreach (var agent in agentList)
            {
                if (locations.TryGetValue(agent.LocationId, out var location))
                {
                    agent.Location = location;
                }
            }
            return agentList;
        }

        public async Task<Agents> GetAgentById(Guid id)
        {
            return await agentsData.GetById(id);
        }
        public async Task AddAgent(AgentRequestDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (await IsUsernameUniqueAsync(model.Username))
            {
                var hashedPass = PasswordHelper.HashPassword(model.Password);
                var newAgent = new Agents
                {
                    Id = Guid.NewGuid(),
                    Username = model.Username,
                    Password = hashedPass,
                    AgentName = model.AgentName,
                    AgentAddress = model.AgentAddress,
                    AgentContactNumber = model.AgentContactNumber,
                    AgentRole = model.AgentRole,
                    DateCreated = DateTime.Now,
                    DateLastLogin = null,
                    LocationId = model.LocationId,
                };

                await agentsData.Create(newAgent);
            }
            else
            {
                throw new InvalidOperationException("Username is already taken.");
            }
        }

        public async Task DeleteAgent(Guid id)
        {
            await agentsData.Delete(id);
        }

        public async Task UpdateAgent(Agents agent)
        {
            await agentsData.Update(agent);
        }

        public async Task<Agents> AgentLogin(string userName, string passWord)
        {
            var agentList = await Task.WhenAll(agentsData.GetAll());
            var locations = (await locationData.GetAll()).ToDictionary(loc => loc.Id);
            var agent = agentList.SelectMany(u => u).FirstOrDefault(a => a.Username == userName);
            if (agent != null && PasswordHelper.VerifyPassword(passWord, agent.Password))
            {
                if (locations.TryGetValue(agent.LocationId, out var location))
                {
                    agent.Location = location;
                }
                return agent;
            }
            else
            {
                throw new InvalidOperationException("Invalid username or password");
            }
        }

        private async Task<bool> IsUsernameUniqueAsync(string username)
        {
            var agentList = await Task.WhenAll(agentsData.GetAll());
            var agent = agentList.SelectMany(u => u).FirstOrDefault(a => a.Username == username);
            if (agent == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
