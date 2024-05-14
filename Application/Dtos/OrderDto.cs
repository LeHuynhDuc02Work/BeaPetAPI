using Core;

namespace Application.Dtos
{
    public class OrderDto
    {
        public int? AddressId { get; set; }
        public string? UserId { get; set; }
        public int? PaymentMethodId { get; set; }
        //public int Code { get; set; }
        public double TotalAmount { get; set; }
        public List<ProductShopCartDto> Products { get; set; }
        //public int Quantity { get; set; }
        //public string? Status { get; set; }
    }

    public class OrderUpdateDto
    {
        public string? Status { get; set; }
    }

    public class OrderViewDto
    {
        public int Id { get; set; }
        public int? AddressId { get; set; }
        public string? UserId { get; set; }
        public int PaymentMethodId { get; set; }
        //public int Code { get; set; }
        public double TotalAmount { get; set; }
        //public int Quantity { get; set; }
        public string? Status { get; set; }
    }
}