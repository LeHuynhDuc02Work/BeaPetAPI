using Core;

namespace Application.Dtos
{
    public class OrderDetailDto
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderDetailViewDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}