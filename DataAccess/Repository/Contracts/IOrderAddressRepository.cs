using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IOrderAddressRepository : IBaseRepository<OrderAddress>
    {
        Task<OrderAddress> GetOrderAddressById(int Id);
        Task<bool> Exists(int Id);
    }
}