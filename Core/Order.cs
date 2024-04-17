using Core.Base;

namespace Core
{
    public class Order : BaseEntity, IBaseEntity
    {
        public int AddressId { get; set; }
        public int Code { get; set; }
        public double TotalAmount { get; set; }
        public int Quantity { get; set; }
        public OrderAddress? Address { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}