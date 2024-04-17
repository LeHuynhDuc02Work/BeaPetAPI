using Core;

namespace Application.Dtos
{
    public class ShopCartDto
    {
        public string? UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
    public class ShopCartViewDto
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}