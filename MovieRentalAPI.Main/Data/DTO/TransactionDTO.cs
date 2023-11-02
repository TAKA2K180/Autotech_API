using MovieRental.Core.Models;

namespace MovieRentalAPI.Main.Data.DTO
{
    public class TransactionDTO
    {
        public decimal TotalAmount { get; set; }
        public Movie MovieDTO { get; set; }
        public Guid MovieId { get; set; }
        public Costumer CostumerDTO { get; set; }
        public Guid CostumerId { get; set; }
        public bool IsReturned { get; set; }
    }
}
