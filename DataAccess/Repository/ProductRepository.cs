using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<Product> GetProductById(int Id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}