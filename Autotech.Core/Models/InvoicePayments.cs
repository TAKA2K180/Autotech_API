using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autotech.Core.Models
{
    public class InvoicePayments : BaseModel
    {
        public DateTime Date { get; set; }
        public string AccountName { get; set; }
        public int Terms { get; set; }
        public double Payment { get; set; }
        public string Status { get; set; }
        public Guid SalesId { get; set; }
    }
}
