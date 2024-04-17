using Core.Base;

namespace Core
{
    public class OrderAddress : BaseEntity, IBaseEntity
    {
        public string? NameCustomer { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}