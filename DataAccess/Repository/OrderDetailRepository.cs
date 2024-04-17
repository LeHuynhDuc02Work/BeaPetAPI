using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class OrderDetailRepository : BaseRepository<OrderDetail>, IOrderDetailRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int Id)
        {
            var result = _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<OrderDetail> GetOrderDetailById(int Id)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}