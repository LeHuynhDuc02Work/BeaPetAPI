using Core;
using DataAccess.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Contracts
{
    public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod>
    {
        Task<PaymentMethod> GetPaymentById(int Id);

        Task<bool> Exists(int Id);
    }
}
