using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ShopCartRepository : BaseRepository<ShopCart>, IShopCartRepository
    {
        private readonly ApplicationDbContext _context;
        public ShopCartRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.ShopCarts.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<ShopCart> GetShopCartById(int Id)
        {
            return await _context.ShopCarts.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}