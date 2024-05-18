using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IBrandRepository _brandRepository;
        private IMenuRepository _menuRepository;
        private INewRepository _newRepository;
        private IOrderAddressRepository _orderAddressRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IOrderRepository _orderRepository;
        private IProductCategoryRepository _productCategoryRepository;
        private IProductRepository _productRepository;
        private IShopCartRepository _shopCartRepository;
        private ISliderRepository _sliderRepository;
        private IUserRepository _userRepository;
        private IPaymentMethodRepository _paymentMethodRepository;
        private IReviewRepository _reviewRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IBrandRepository BrandRepository => _brandRepository ??= new BrandRepository(_context);

        public IMenuRepository MenuRepository => _menuRepository ??= new MenuRepository(_context);

        public INewRepository NewRepository => _newRepository ??= new NewRepository(_context);

        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository(_context);

        public IOrderAddressRepository OrderAddressRepository => _orderAddressRepository ??= new OrderAddressRepository(_context);

        public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository ??= new OrderDetailRepository(_context);

        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

        public IShopCartRepository ShopCartRepository => _shopCartRepository ??= new ShopCartRepository(_context);

        public ISliderRepository SliderRepository => _sliderRepository ??= new SliderRepository(_context);

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_context);

        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository ??= new ProductCategoryRepository(_context);
       
        public IPaymentMethodRepository PaymentMethodRepository => _paymentMethodRepository ??= new PaymentMethodRepository(_context);
        public IReviewRepository ReviewRepository => _reviewRepository ??= new ReviewRepository(_context);
    }
}
