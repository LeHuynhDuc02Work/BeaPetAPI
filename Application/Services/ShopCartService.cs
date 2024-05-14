using Application.Contracts;
using Application.Dtos;
using AutoMapper;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ShopCartService : IShopCartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShopCartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ShopCartViewDto>> GetAllByUserId(string id)
        {
            var shopCart = _unitOfWork.ShopCartRepository.GetAll()
                            .Where(x => x.UserId.Trim() == id.Trim());

            var shopCartMap = _mapper.Map<List<ShopCartViewDto>>(shopCart);
            return shopCartMap;
        }

        public async Task<ShopCartViewDto> GetById(int id)
        {
            var shopCart = await _unitOfWork.ShopCartRepository.GetShopCartById(id);
            if (shopCart == null)
                throw new ApplicationException("NotFound");
            var shopCartMap = _mapper.Map<ShopCartViewDto>(shopCart);
            return shopCartMap;
        }

        public async Task<ShopCartViewDto> Create(ShopCartDto shopCartCreate)
        {
            if (shopCartCreate == null)
                throw new ApplicationException("NoContent");

            var productCheck = _unitOfWork.ShopCartRepository
                                    .GetAll()
                                    .Where(x => x.ProductId == shopCartCreate.ProductId && x.UserId.Trim() == shopCartCreate.UserId.Trim())
                                    .FirstOrDefault();
            if (productCheck != null)
            {
                productCheck.Quantity = productCheck.Quantity + shopCartCreate.Quantity;
                _unitOfWork.ShopCartRepository.Update(productCheck);
                await _unitOfWork.ShopCartRepository.SaveChange();
                return _mapper.Map<ShopCartViewDto>(productCheck);
            }    
            else
            {
                var _shopCart = _mapper.Map<ShopCart>(shopCartCreate);
                await _unitOfWork.ShopCartRepository.Create(_shopCart);
                await _unitOfWork.ShopCartRepository.SaveChange();
                return _mapper.Map<ShopCartViewDto>(_shopCart);
            }    
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _unitOfWork.ShopCartRepository.Exists(id))
                throw new ApplicationException("NotFound");

            var _shopCart = await _unitOfWork.ShopCartRepository.GetShopCartById(id);
            _unitOfWork.ShopCartRepository.Delete(_shopCart);

            return await _unitOfWork.ShopCartRepository.SaveChange();
        }

        public async Task<ShopCartViewDto> Update(int id, ShopCartUpdateDto shopCartUpdate)
        {
            if (!await _unitOfWork.ShopCartRepository.Exists(id) || shopCartUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var _shopCart = await _unitOfWork.ShopCartRepository.GetShopCartById(id);
            _shopCart.Quantity = shopCartUpdate.Quantity;

            _unitOfWork.ShopCartRepository.Update(_shopCart);
            await _unitOfWork.ShopCartRepository.SaveChange();

            return _mapper.Map<ShopCartViewDto>(_shopCart);
        }

        public async Task<bool> DeleteByProductId(int id)
        {
            var shopcart = _unitOfWork.ShopCartRepository.GetAll().Where(x => x.ProductId == id).FirstOrDefault();
            if (shopcart == null)
                throw new ApplicationException("NotFound");
            _unitOfWork.ShopCartRepository.Delete(shopcart);
            return await _unitOfWork.ShopCartRepository.SaveChange();
        }

        public async Task<ShopCartViewDto> UpdateQuantity(int id, ShopCartUpdateDto shopCartUpdate)
        {
            var _shopCart = await _unitOfWork.ShopCartRepository.GetAll().Where(x => x.ProductId == id).FirstOrDefaultAsync();
            _shopCart.Quantity = shopCartUpdate.Quantity;

            _unitOfWork.ShopCartRepository.Update(_shopCart);
            await _unitOfWork.ShopCartRepository.SaveChange();

            return _mapper.Map<ShopCartViewDto>(_shopCart);
        }
    }
}