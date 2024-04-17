using Core;

namespace Application.Dtos
{
    public class OrderAddressDto
    {
        public string? NameCustomer { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
    public class OrderAddressViewDto
    {
        public int? Id { get; set; }
        public string? NameCustomer { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}