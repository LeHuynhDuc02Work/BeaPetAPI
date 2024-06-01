using Application.Dtos;
using System.Security.Cryptography;

namespace Application.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderViewDto>> GetAll(InputSearchDto inputSearch);
        Task<List<OrderViewDto>> GetAllByUserId(string id, InputSearchDto inputSearch);
        Task<List<ProductOrderDetailDto>> GetAllProductById(int id);
        Task<OrderViewDto> GetById(int id);
        Task<List<OrderStatisticalDto>> GetOrderStatiscal(string Status, int fromMonth, int toMonth, int Year);
        Task<OrderViewDto> Create(OrderDto orderCreate);
        Task<OrderViewDto> Update(int id, OrderUpdateDto orderUpdate);
        Task<bool> Delete(int id);
    }
}