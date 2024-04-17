using Application.Dtos;

namespace Application.Contracts
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetailViewDto>> GetAll();
        Task<OrderDetailViewDto> GetById(int id, InputSearchDto inputSearch);
        Task<OrderDetailViewDto> Create(OrderDetailDto orderDetailCreate);
        Task<OrderDetailViewDto> Update(int id, OrderDetailDto orderDetailUpdate);
        Task<bool> Delete(int id);
    }
}