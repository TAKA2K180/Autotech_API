using Autotech.Core.Models;

namespace Autotech.BusinessLayer.Data.DTO
{
    public class TransactionDTO
    {
        public Accounts CostumerDTO { get; set; }
        public Guid CostumerId { get; set; }
        public bool IsReturned { get; set; }
    }
}
