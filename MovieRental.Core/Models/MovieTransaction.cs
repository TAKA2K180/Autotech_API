using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Core.Models
{
    [DisplayName("Transactions")]
    public class MovieTransaction : BaseModel
    {
        public decimal TotalAmount { get; set; }
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
        public Costumer Costumer { get; set; }
        public Guid CostumerId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public bool IsReturned { get; set; }
    }
}
