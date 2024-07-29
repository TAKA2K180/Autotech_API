using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotech.Core.Models
{
    public class Agents : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AgentName { get; set; }
        public string AgentContactNumber { get; set; }
        public string AgentAddress { get; set; }
        public string AgentRole { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateLastLogin { get; set; }
        // Foreign key to Location
        public Guid LocationId { get; set; }
        public Locations Location { get; set; }
    }
}
