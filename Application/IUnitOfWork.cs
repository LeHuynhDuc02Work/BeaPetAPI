using Application.Contracts;
using DataAccess.Repository.Contracts;

namespace Application
{
    public interface IUnitOfWork
    {
        IBrandRepository BrandRepository { get; } 
        IMenuRepository MenuRepository { get; } 
        INewRepository NewRepository { get; } 
        IOrderRepository OrderRepository { get; } 
        IOrderAddressRepository OrderAddressRepository { get; } 
        IOrderDetailRepository OrderDetailRepository { get; } 
        IProductRepository ProductRepository { get; } 
        IShopCartRepository ShopCartRepository { get; }
        ISliderRepository SliderRepository { get; }

    }
}