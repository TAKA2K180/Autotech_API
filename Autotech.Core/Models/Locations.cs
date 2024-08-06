﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace Autotech.Core.Models
{
    public class Locations : BaseModel
    {
        public string LocationName { get; set; }

        // Navigation properties
        [JsonIgnore]
        public ICollection<Sales> Sales { get; set; } = new List<Sales>();
        [JsonIgnore]
        public ICollection<Agents> Agents { get; set; } = new List<Agents>();
        [JsonIgnore]
        public ICollection<Accounts> Accounts { get; set; } = new List<Accounts>();
    }
}
