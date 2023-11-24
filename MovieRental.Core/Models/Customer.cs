using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieRental.Core.Models
{
    public class Customer : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isActive { get; set; }

        [JsonIgnore]
        public ICollection<MovieTransaction> MovieTransactions { get; set; }
        [JsonIgnore]
        public ICollection<Rentals> Rentals { get; set; }
    }
}
