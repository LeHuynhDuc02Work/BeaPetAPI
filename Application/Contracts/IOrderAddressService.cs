using Application.Dtos;

namespace Application.Contracts
{
    public interface IOrderAddressService
    {
        Task<List<OrderAddressViewDto>> GetAll();
        Task<OrderAddressViewDto> GetById(int id, InputSearchDto inputSearch);
        Task<OrderAddressViewDto> Create(OrderAddressDto orderAddressCreate);
        Task<OrderAddressViewDto> Update(int id, OrderAddressDto orderAddressUpdate);
        Task<bool> Delete(int id);
    }
}