using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<ProductCategory> GetProductCategoryById(int Id)
        {
            return await _context.ProductCategories.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}