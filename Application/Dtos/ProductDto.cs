namespace Application.Dtos
{
    public class ProductDto
    {
        public int BrandId { get; set; }
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductOrderDetailDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double SalePrice { get; set; }
        public int OrderQuantity { get; set; }

    }

    public class ProductShopCartDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ProductCategoryId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public int Quantity { get; set; }
        public int QuantityShopCart { get; set; }

    }

    public class ProductAnalysDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public double? SalePrice { get; set; }
        public int? SellQuantity { get; set; }
        public int? Quantity { get; set; }
    }

    public class ProductViewDto
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ProductCategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Image { get; set; }
        public double? Price { get; set; }
        public double? SalePrice { get; set; }
        public int? Quantity { get; set; }
    }

}