using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Core;

namespace Application.Services
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderAddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<OrderAddressViewDto>> GetAllByUserId(string userId)
        {
            var addresses = _unitOfWork.OrderAddressRepository.GetAll()
                            .Where(x => x.UserId.Trim() == userId.Trim()).OrderByDescending(x=>x.Id);

            var addressesMap = _mapper.Map<List<OrderAddressViewDto>>(addresses);
            return addressesMap;
        }

        public async Task<OrderAddressViewDto> GetById(int id)
        {
            var address = await _unitOfWork.OrderAddressRepository.GetOrderAddressById(id);
            if (address == null)
                throw new ApplicationException("NotFound");
            var addressMap = _mapper.Map<OrderAddressViewDto>(address);
            return addressMap;
        }

        public async Task<OrderAddressViewDto> Create(OrderAddressCreateDto orderAddressCreate)
        {
            if (orderAddressCreate == null)
                throw new ApplicationException("NoContent");

            var _address = _mapper.Map<OrderAddress>(orderAddressCreate);
            await _unitOfWork.OrderAddressRepository.Create(_address);
            await _unitOfWork.OrderAddressRepository.SaveChange();

            return _mapper.Map<OrderAddressViewDto>(_address);
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _unitOfWork.OrderAddressRepository.Exists(id))
                throw new ApplicationException("NotFound");

            var _product = await _unitOfWork.OrderAddressRepository.GetOrderAddressById(id);
            _unitOfWork.OrderAddressRepository.Delete(_product);


            return await _unitOfWork.OrderAddressRepository.SaveChange();
        }

        public async Task<OrderAddressViewDto> Update(int id, OrderAddressDto orderAddressUpdate)
        {
            if (!await _unitOfWork.OrderAddressRepository.Exists(id) || orderAddressUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var _address = await _unitOfWork.OrderAddressRepository.GetOrderAddressById(id);
            _address.NameCustomer = orderAddressUpdate.NameCustomer;
            _address.Phone = orderAddressUpdate.Phone;
            _address.Address = orderAddressUpdate.Address;


            _unitOfWork.OrderAddressRepository.Update(_address);
            await _unitOfWork.OrderAddressRepository.SaveChange();

            return _mapper.Map<OrderAddressViewDto>(_address);
        }
    }
}