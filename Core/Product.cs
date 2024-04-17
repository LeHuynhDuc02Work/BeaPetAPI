using Core.Base;

namespace Core
{
    public class Product : BaseEntity, IBaseEntity
    {
        public int BrandId { get; set; }
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Image { get; set; }
        public double? Price { get; set; }
        public double? SalePrice { get; set; }
        public int? Quantity { get; set; }
        public Brand? Brand { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        public ICollection<ShopCart>? ShopCarts { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}