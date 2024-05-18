using Application.Dtos;

namespace Application.Contracts
{
    public interface IOrderDetailService
    {
        Task<List<OrderDetailViewDto>> GetAll();
        Task<List<OrderDetailViewDto>> GetAllByOrderId(int id);
        Task<List<ProductAnalysDto>> GetAllProductToAnalys(InputSearchDto inputSearch);
        Task<OrderDetailViewDto> GetById(int id);
        Task<OrderDetailViewDto> Create(OrderDetailDto orderDetailCreate);
        Task<OrderDetailViewDto> Update(int id, OrderDetailDto orderDetailUpdate);
        Task<bool> Delete(int id);
    }
}