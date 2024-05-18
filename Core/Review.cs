using Core.Base;

namespace Core
{
    public class Review : BaseEntity, IBaseEntity
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public string? Content { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}