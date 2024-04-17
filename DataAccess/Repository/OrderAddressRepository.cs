using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class OrderAddressRepository : BaseRepository<OrderAddress>, IOrderAddressRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderAddressRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.OrderAddresses.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<OrderAddress> GetOrderAddressById(int Id)
        {
            return await _context.OrderAddresses.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}