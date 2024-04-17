using Application.Dtos;

namespace Application.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderViewDto>> GetAll();
        Task<OrderViewDto> GetById(int id, InputSearchDto inputSearch);
        Task<OrderViewDto> Create(OrderDto orderCreate);
        Task<OrderViewDto> Update(int id, OrderDto orderUpdate);
        Task<bool> Delete(int id);
    }
}