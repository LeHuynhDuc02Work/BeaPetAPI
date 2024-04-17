using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IShopCartRepository : IBaseRepository<ShopCart>
    {
        Task<ShopCart> GetShopCartById(int Id);

        Task<bool> Exists(int Id);
    }
}