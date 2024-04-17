namespace Application.Dtos
{
    public class BrandDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }

    public class BrandViewDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}