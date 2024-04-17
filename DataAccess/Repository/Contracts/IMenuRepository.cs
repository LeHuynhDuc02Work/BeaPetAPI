using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IMenuRepository : IBaseRepository<Menu>
    {
        Task<Menu> GetMenuById(int Id);

        Task<bool> Exists(int Id);
    }
}