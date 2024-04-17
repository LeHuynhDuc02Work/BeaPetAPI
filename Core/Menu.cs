using Core.Base;

namespace Core
{
    public class Menu : BaseEntity, IBaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Position { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}