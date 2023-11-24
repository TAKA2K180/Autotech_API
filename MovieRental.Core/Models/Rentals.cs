using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieRental.Core.Models
{
    public class Rentals : BaseModel
    {
        public Guid CustomerId { get; set; }
        public Guid MovieId { get; set; }
        public Guid TransactionId { get; set; }
        public Movie Movie { get; set; }
        public Customer Customer { get; set; }
        public MovieTransaction Transaction { get; set; }
    }
}
