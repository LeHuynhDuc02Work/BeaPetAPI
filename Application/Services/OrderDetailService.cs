using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

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

        public async Task<List<ProductAnalysDto>> GetAllProductToAnalys(InputSearchDto inputSearch)
        {
            
            if (inputSearch.search.Trim() == "Sản phẩm bán chậm(10)")
            {
                var allProducts = _unitOfWork.ProductRepository.GetAll();
                var orderItems = _unitOfWork.OrderDetailRepository.GetAll();

                List<ProductAnalysDto> productAnalyses = new List<ProductAnalysDto>();
                foreach (var item in allProducts)
                {
                    if (orderItems.FirstOrDefault(x => x.ProductId == item.Id) == null)
                    {
                        var productTg = new ProductAnalysDto();
                        productTg.Id = item.Id;
                        productTg.SalePrice = item.SalePrice;
                        productTg.Image = item.Image;
                        productTg.Quantity = item.Quantity;
                        productTg.Name = item.Name;
                        productTg.SellQuantity = 0;
                        productAnalyses.Add(productTg);
                    }
                    if (productAnalyses.Count == 10) break;
                }
                if (productAnalyses.Count < 10)
                {
                    var orderDetails = _unitOfWork.OrderDetailRepository.GetAll();
                    var products = orderDetails.GroupBy(o => o.ProductId)
                                            .ToDictionary(g => g.Key, g => g.Count())
                                            .OrderBy(x => x.Value);
                    int index = productAnalyses.Count;
                 
                    foreach (var item in products)
                    {
                        Product product = await _unitOfWork.ProductRepository.GetProductById(item.Key);
                        ProductAnalysDto productAnalys = new ProductAnalysDto();
                        productAnalys.Id = product.Id;
                        productAnalys.Name = product.Name;
                        productAnalys.Image = product.Image;
                        productAnalys.SalePrice = product.SalePrice;
                        productAnalys.Quantity = product.Quantity;
                        productAnalys.SellQuantity = item.Value;
                        productAnalyses.Add(productAnalys);
                        index++;
                        if (index == 10) break;
                    }
                }   
                return productAnalyses;
            }
            else
            {
                var orderDetails = _unitOfWork.OrderDetailRepository.GetAll();
                var products = orderDetails.GroupBy(o => o.ProductId)
                                        .ToDictionary(g => g.Key, g => g.Count())
                                        .OrderByDescending(x => x.Value);
                List<ProductAnalysDto> productAnalyses = new List<ProductAnalysDto>();
                foreach (var item in products)
                {
                    Product product = await _unitOfWork.ProductRepository.GetProductById(item.Key);
                    ProductAnalysDto productAnalys = new ProductAnalysDto();
                    productAnalys.Id = product.Id;
                    productAnalys.Name = product.Name;
                    productAnalys.Image = product.Image;
                    productAnalys.SalePrice = product.SalePrice;
                    productAnalys.Quantity = product.Quantity;
                    productAnalys.SellQuantity = item.Value;
                    productAnalyses.Add(productAnalys);
                }
                var pagination = new PaginationHelper<ProductAnalysDto>();
                var productAnalysesPagination = pagination.Paginate(productAnalyses, inputSearch.page, inputSearch.pageSize);
                return _mapper.Map<List<ProductAnalysDto>>(productAnalysesPagination);
            }    
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