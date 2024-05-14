using Application.Dtos;

namespace Application.Contracts
{
    public interface IOrderAddressService
    {
        Task<List<OrderAddressViewDto>> GetAllByUserId(string userId);
        Task<OrderAddressViewDto> GetById(int id);
        Task<OrderAddressViewDto> Create(OrderAddressCreateDto OrderAddressCreate);
        Task<OrderAddressViewDto> Update(int id, OrderAddressDto orderAddressUpdate);
        Task<bool> Delete(int id);
    }
}