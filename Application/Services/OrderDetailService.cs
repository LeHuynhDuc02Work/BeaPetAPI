using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;

namespace Application.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderDetailService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailViewDto>> GetAllByOrderId(int id)
        {
            var orderDetails = _unitOfWork.OrderDetailRepository.GetAll()
                        .Where(x => x.OrderId == id).OrderByDescending(x => x.Id);

            var orderDetailsMap = _mapper.Map<List<OrderDetailViewDto>>(orderDetails);
            return orderDetailsMap;
        }

        public async Task<OrderDetailViewDto> Create(OrderDetailDto orderDetailCreate)
        {
            if (orderDetailCreate == null)
                throw new ApplicationException("NoContent");

            var _orderDetail = _mapper.Map<OrderDetail>(orderDetailCreate);
            await _unitOfWork.OrderDetailRepository.Create(_orderDetail);
            
            var product = await _unitOfWork.ProductRepository.GetProductById(_orderDetail.ProductId);
            product.Quantity -= orderDetailCreate.Quantity;
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.OrderDetailRepository.SaveChange();

            return _mapper.Map<OrderDetailViewDto>(_orderDetail);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDetailViewDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailViewDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDetailViewDto> Update(int id, OrderDetailDto orderDetailUpdate)
        {
            throw new NotImplementedException();
        }
    }
}