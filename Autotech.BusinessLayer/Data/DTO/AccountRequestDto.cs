using Autotech.Core.Models;

namespace Autotech.BusinessLayer.Data.DTO
{
    public class AccountRequestDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public string ContactPerson { get; set; }
        public int Terms { get; set; }
        public float Discount { get; set; }
        public string Cluster { get; set; }
        public double LitersOrdered { get; set; }
        public int OpenReceipts { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public AccountDetails AccountDetails { get; set; }
    }
}
