using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        Task<ProductCategory> GetProductCategoryById(int Id);

        Task<bool> Exists(int Id);
    }
}