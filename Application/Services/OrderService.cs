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
            var orders = _unitOfWork.OrderRepository.GetAll().OrderByDescending(x => x.Id); ;
            if (inputSearch.search != "Tất cả")
            {
                orders = _unitOfWork.OrderRepository.GetAll()
                                .Where(x => x.Status.Trim() == inputSearch.search.Trim())
                                .OrderByDescending(x => x.Id);
            } 
            var pagination = new PaginationHelper<Order>();
            var ordersPagination = pagination.Paginate(orders, inputSearch.page, inputSearch.pageSize);
            var ordersMap = _mapper.Map<List<OrderViewDto>>(ordersPagination);
            foreach (var order in ordersMap)
            {
                var address = await _unitOfWork.OrderAddressRepository.GetOrderAddressById(order.AddressId);
                order.Address = _mapper.Map<OrderAddressDto>(address);
            }    
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
            _order.Status = "Đang chuẩn bị hàng";
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
        public async Task<List<OrderStatisticalDto>> GetOrderStatiscal(string Status, int fromMonth, int toMonth, int Year)
        {
            try
            {   
                var orders = _unitOfWork.OrderRepository.GetAll()
                .Where(x => x.Status.Trim() == Status.Trim())
                .OrderByDescending(x => x.CreatedOn);
                if (Year != 0)
                {
                    orders = _unitOfWork.OrderRepository.GetAll()
                    .Where(x => x.Status.Trim() == Status.Trim() && x.CreatedOn.Year == Year)
                    .OrderByDescending(x => x.CreatedOn);
                }    
                var totalAmountByMonth = orders.GroupBy(o => new Tuple<int, int>(o.CreatedOn.Month, o.CreatedOn.Year))
                                   .ToDictionary(g => g.Key, g => g.Sum(o => o.TotalAmount));
                var totalOrdersByMonth = orders.GroupBy(o => new Tuple<int, int>(o.CreatedOn.Month, o.CreatedOn.Year))
                                   .ToDictionary(g => g.Key, g => g.Count());
                List<OrderStatisticalDto> orderStatisticals = new List<OrderStatisticalDto>();
                int i = 0;
                foreach (var result in totalAmountByMonth)
                {
                    OrderStatisticalDto order = new OrderStatisticalDto()
                    {
                        Month = result.Key.Item1.ToString() + "/" + result.Key.Item2.ToString(),
                        Month1 = result.Key.Item1,
                        SellPrice = result.Value,
                        TotalOrder = totalOrdersByMonth[result.Key]
                    };
                    orderStatisticals.Add(order);
                }

                if (fromMonth!=0 && toMonth!=0 && Year!=0)
                    return orderStatisticals.Where(x=>x.Month1 >= fromMonth && x.Month1 <= toMonth).ToList();
                return orderStatisticals;
            }
            catch(Exception e)
            {
                throw new ApplicationException("Error: " + e.Message);
            }
            
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}