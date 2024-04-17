using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface INewRepository : IBaseRepository<New>
    {
        Task<New> GetNewById(int Id);

        Task<bool> Exists(int Id);
    }
}