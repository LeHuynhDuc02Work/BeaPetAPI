using Core;
using DataAccess.Repository.Common;

namespace DataAccess.Repository.Contracts
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<Product> GetProductById(int Id);
        Task<bool> Exists(int Id); 
    }
}