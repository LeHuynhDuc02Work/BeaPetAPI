using Application.Dtos;
using Core;

namespace Application.Contracts
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethodViewDto>> GetAll();

        Task<PaymentMethodViewDto> GetById(int id);

        Task<PaymentMethodViewDto> Create(PaymentMethodDto paymentCreate);

        Task<PaymentMethodViewDto> Update(int id, PaymentMethodDto paymentUpdate);

        Task<bool> Delete(int id);
    }
}