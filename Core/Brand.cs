using Core.Base;

namespace Core
{
    public class Brand : BaseEntity, IBaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        //public ICollection<Product>? Products { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}