using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<PaymentMethodViewDto>> GetAll()
        {
            var payments = _unitOfWork.PaymentMethodRepository.GetAll();

            var paymentsMap = _mapper.Map<List<PaymentMethodViewDto>>(payments);
            return paymentsMap;
        }

        public async Task<PaymentMethodViewDto> GetById(int id)
        {
            var payment = await _unitOfWork.PaymentMethodRepository.GetPaymentById(id);
            if (payment == null)
                throw new ApplicationException("NotFound");
            var paymentMap = _mapper.Map<PaymentMethodViewDto>(payment);
            return paymentMap;
        }

        public Task<PaymentMethodViewDto> Create(PaymentMethodDto paymentCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentMethodViewDto> Update(int id, PaymentMethodDto paymentUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
