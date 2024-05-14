using Application.Contracts;
using Application.Dtos;
using Application.Helpers;
using AutoMapper;
using Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IOrderDetailService _orderDetailService;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper, IOrderDetailService orderDetailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _orderDetailService = orderDetailService;
        }

        public async Task<List<OrderViewDto>> GetAll(InputSearchDto inputSearch)
        {
            var orders = _unitOfWork.OrderRepository.GetAll().OrderByDescending(x => x.Id);

            var pagination = new PaginationHelper<Order>();
            var ordersPagination = pagination.Paginate(orders, inputSearch.page, inputSearch.pageSize);
            var ordersMap = _mapper.Map<List<OrderViewDto>>(ordersPagination);
            return ordersMap;
        }

        public async Task<List<OrderViewDto>> GetAllByUserId(string id, InputSearchDto inputSearch)
        {
            var orders = _unitOfWork.OrderRepository.GetAll().Where(x => x.UserId.Trim() == id.Trim()).OrderByDescending(x => x.Id);

            var pagination = new PaginationHelper<Order>();
            var ordersPagination = pagination.Paginate(orders, inputSearch.page, inputSearch.pageSize);
            var ordersMap = _mapper.Map<List<OrderViewDto>>(ordersPagination);
            return ordersMap;
        }

        public async Task<List<ProductOrderDetailDto>> GetAllProductById(int id)
        {
            var orderDetails = _unitOfWork.OrderDetailRepository.GetAll().Where(x => x.OrderId == id).OrderByDescending(x => x.ProductId);
            List<ProductOrderDetailDto> products = new List<ProductOrderDetailDto>();
            foreach(var order in orderDetails)
            {
                Product product = await _unitOfWork.ProductRepository.GetProductById(order.ProductId);
                ProductOrderDetailDto protg = new ProductOrderDetailDto()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.Image,
                    SalePrice = product.SalePrice,
                    OrderQuantity = order.Quantity
                };
                products.Add(protg);
            }    
            return products;
        }

        public async Task<OrderViewDto> GetById(int id)
        {
            var _order = await _unitOfWork.OrderRepository.GetOrderById(id);
            if (_order == null)
                throw new ApplicationException("NotFound");
            var orderMap = _mapper.Map<OrderViewDto>(_order);
            return orderMap;
        }

        public async Task<OrderViewDto> Create(OrderDto orderCreate)
        {
            if (orderCreate == null)
                throw new ApplicationException("NoContent");

            var _order = _mapper.Map<Order>(orderCreate);
            _order.Status = "Đang chuẩn bị hàng!";
            _order.CreatedOn = DateTime.Now;
            await _unitOfWork.OrderRepository.Create(_order);
            await _unitOfWork.OrderRepository.SaveChange();
            var orderMap = _mapper.Map<OrderViewDto>(_order);

            foreach (var product in orderCreate.Products)
            {
                OrderDetailDto orderDetailCreate = new OrderDetailDto()
                {
                    OrderId = orderMap.Id,
                    ProductId = product.Id,
                    Price = product.SalePrice,
                    Quantity = product.QuantityShopCart
                };
                await _orderDetailService.Create(orderDetailCreate);
                var shopcart = await _unitOfWork.ShopCartRepository.GetAll()
                    .Where(x => x.ProductId == product.Id && x.UserId.Trim() == orderMap.UserId.Trim())
                    .FirstOrDefaultAsync();
                _unitOfWork.ShopCartRepository.Delete(shopcart);
                await _unitOfWork.OrderRepository.SaveChange();
            }
            return orderMap;
        }

        public async Task<OrderViewDto> Update(int id, OrderUpdateDto orderUpdate)
        {
            if (!await _unitOfWork.OrderRepository.Exists(id) || orderUpdate == null)
                throw new ApplicationException("NoContent or NotFound");

            var _order = await _unitOfWork.OrderRepository.GetOrderById(id);
            _order.Status = orderUpdate.Status;
            _order.UpdatedOn = DateTime.Now;
            _unitOfWork.OrderRepository.Update(_order);
            await _unitOfWork.OrderRepository.SaveChange();

            return _mapper.Map<OrderViewDto>(_order);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}