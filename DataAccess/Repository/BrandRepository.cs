using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class BrandRepository : BaseRepository<Brand>, IBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public BrandRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.Brands.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<Brand> GetBrandById(int Id)
        {
            return await _context.Brands.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}