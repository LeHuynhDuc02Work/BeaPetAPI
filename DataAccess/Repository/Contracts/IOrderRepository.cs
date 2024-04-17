using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetOrderById(int Id);
        Task<bool> Exists(int Id);
    }
}