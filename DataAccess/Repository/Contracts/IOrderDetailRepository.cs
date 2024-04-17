using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IOrderDetailRepository : IBaseRepository<OrderDetail>
    {
        Task<OrderDetail> GetOrderDetailById(int Id);
        Task<bool> Exists(int Id);
    }
}