using Core;
using DataAccess.Repository.Common;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethod>, IPaymentMethodRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentMethodRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> Exists(int Id)
        {
            var result = _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == Id);
            return await result != null;
        }

        public async Task<PaymentMethod> GetPaymentById(int Id)
        {
            return await _context.PaymentMethods.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
