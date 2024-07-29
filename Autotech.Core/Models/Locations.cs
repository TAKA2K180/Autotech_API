using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace Autotech.Core.Models
{
    public class Locations : BaseModel
    {
        public string LocationName { get; set; }

        // Navigation properties
        public ICollection<Sales> Sales { get; set; }
        public ICollection<Agents> Agents { get; set; }
        public ICollection<Accounts> Accounts { get; set; }
    }
}
