using Core.Base;

namespace Core
{
    public class OrderDetail : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        //public Order? Order { get; set; }
        //public Product? Product { get; set; }
    }
}