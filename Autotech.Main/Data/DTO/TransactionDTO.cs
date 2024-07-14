using Autotech.Core.Models;

namespace Autotech.Main.Data.DTO
{
    public class TransactionDTO
    {
        public Customer CostumerDTO { get; set; }
        public Guid CostumerId { get; set; }
        public bool IsReturned { get; set; }
    }
}
