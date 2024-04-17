using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class MenuRepository : BaseRepository<Menu>, IMenuRepository
    {
        private readonly ApplicationDbContext _context;

        public MenuRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.Menus.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<Menu> GetMenuById(int Id)
        {
            return await _context.Menus.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}