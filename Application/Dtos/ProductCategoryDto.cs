namespace Application.Dtos
{
    public class ProductCategoryDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        //public string? Icon { get; set; }
    }

    public class ProductCategoryViewDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public int? Quantity { get; set; }
        public string? Status { get; set; }
    }
}