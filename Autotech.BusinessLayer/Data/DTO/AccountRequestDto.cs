using Autotech.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Autotech.BusinessLayer.Data.DTO
{
    public class AccountRequestDto
    {
        public string Name { get; set; }
        public string? ContactPerson { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public string? Address { get; set; }
        public int Terms { get; set; }
        public double DiscountPercent { get; set; }
        public string? Cluster { get; set; }
        public bool isActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public AccountDetails AccountDetails { get; set; }
        // Foreign key to Location
        public Guid LocationId { get; set; }
        public Locations Location { get; set; }
        public double LitersOrdered { get; set; }
        public int OpenReceipts { get; set; }
    }
}
