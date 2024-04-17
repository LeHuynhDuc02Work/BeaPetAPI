using Core;

namespace Application.Dtos
{
    public class OrderDto
    {
        public int AddressId { get; set; }
        public int Code { get; set; }
        public double TotalAmount { get; set; }
        public int Quantity { get; set; }
    }
    public class OrderViewDto
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int Code { get; set; }
        public double TotalAmount { get; set; }
        public int Quantity { get; set; }
    }
}