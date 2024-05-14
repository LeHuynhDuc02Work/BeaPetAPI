using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<ProductViewDto>> GetAll(InputSearchDto inputSearch)
        {
            var products = _unitOfWork.ProductRepository.GetAll()
                            .Where(x => x.Name.ToUpper().Trim().Contains(inputSearch.search.ToUpper().Trim()))
                            .OrderByDescending(x => x.Id);
            if (inputSearch.sort == "DESC")
            {
                products = products.OrderByDescending(x => x.SalePrice);
            }
            if (inputSearch.sort == "ASC")
            {
                products = products.OrderBy(x => x.SalePrice);
            }
            var pagination = new PaginationHelper<Product>();
            var productsPagination = pagination.Paginate(products, inputSearch.page, inputSearch.pageSize);
            var productsMap = _mapper.Map<List<ProductViewDto>>(productsPagination);
            foreach (var product in productsMap)
            {
                    ProductCategory cate = await _unitOfWork.ProductCategoryRepository.GetProductCategoryById(product.ProductCategoryId);
                    product.CategoryName = cate.Name;  
            }    
            return productsMap;
        }

        public async Task<ProductViewDto> GetById(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetProductById(id);
            if (product == null)
                throw new ApplicationException("NotFound");
            var productMap = _mapper.Map<ProductViewDto>(product);
            return productMap;
        }

        public async Task<ProductViewDto> Create(ProductDto productCreate)
        {
            if (productCreate == null)
                throw new ApplicationException("NoContent");

            var _product = _mapper.Map<Product>(productCreate);
            await _unitOfWork.ProductRepository.Create(_product);
            await _unitOfWork.ProductRepository.SaveChange();

            var category = await _unitOfWork.ProductCategoryRepository.GetProductCategoryById(_product.ProductCategoryId);
            category.Quantity = category.Quantity + 1;
            await _unitOfWork.ProductCategoryRepository.SaveChange();

            return _mapper.Map<ProductViewDto>(_product);
        }

        public async Task<bool> Delete(int id)
        {
            if (!await _unitOfWork.ProductRepository.Exists(id))
                throw new ApplicationException("NotFound");

            var _product = await _unitOfWork.ProductRepository.GetProductById(id);
            _unitOfWork.ProductRepository.Delete(_product);

            var category = await _unitOfWork.ProductCategoryRepository.GetProductCategoryById(_product.ProductCategoryId);
            category.Quantity = category.Quantity - 1;
            //await _unitOfWork.ProductCategoryRepository.SaveChange();

            return await _unitOfWork.ProductRepository.SaveChange();
        }

        public async Task<ProductViewDto> Update(int id, ProductDto productUpdate)
        {
            if (!await _unitOfWork.ProductRepository.Exists(id) || productUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var _product = await _unitOfWork.ProductRepository.GetProductById(id);
            _product.BrandId = productUpdate.BrandId;
            _product.ProductCategoryId = productUpdate.ProductCategoryId;
            _product.Name = productUpdate.Name;
            _product.Description = productUpdate.Description;
            _product.Detail = productUpdate.Detail;
            _product.Image = productUpdate.Image;
            _product.Price = productUpdate.Price;
            _product.SalePrice = productUpdate.SalePrice;
            _product.Quantity = productUpdate.Quantity;
            _unitOfWork.ProductRepository.Update(_product);
            await _unitOfWork.ProductRepository.SaveChange();

            return _mapper.Map<ProductViewDto>(_product);
        }

        public async Task<List<ProductShopCartDto>> GetAllByUserId(string id)
        {
            List<ProductShopCartDto> productsShopcart = new List<ProductShopCartDto>();
            var listShopCart = _unitOfWork.ShopCartRepository.GetAll().Where(x => x.UserId.Trim() == id.Trim());
            foreach (var item in listShopCart)
            {
                var product = await _unitOfWork.ProductRepository.GetProductById(item.ProductId);
                var productShopCart = new ProductShopCartDto()
                {
                    Id = product.Id,
                    Name = product?.Name,
                    Detail = product?.Detail,
                    Image = product?.Image,
                    Price = product.Price,
                    SalePrice = product.SalePrice,
                    Quantity = product.Quantity,
                    Description = product?.Description,
                    QuantityShopCart = item.Quantity
                };
                productsShopcart.Add(productShopCart);
            }

            return productsShopcart;
        }
    }
}