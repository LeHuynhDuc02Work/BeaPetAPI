using Core.Base;

namespace Core
{
    public class ShopCart : BaseEntity
    {
        public string? UserId { get; set; }
        public int ProductId { get; set; }
        public User? User { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}