using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IBrandRepository : IBaseRepository<Brand>
    {
        Task<Brand> GetBrandById(int Id);

        Task<bool> Exists(int Id);
    }
}