using Core.Base;

namespace Core
{
    public class ProductCategory : BaseEntity, IBaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public int Quantity { get; set; }
        //public ICollection<Product>? Products { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}