﻿using Application.Dtos;

namespace Application.Contracts
{
    public interface IOrderService
    {
        Task<List<OrderViewDto>> GetAll(InputSearchDto inputSearch);
        Task<List<OrderViewDto>> GetAllByUserId(string id, InputSearchDto inputSearch);
        Task<List<ProductOrderDetailDto>> GetAllProductById(int id);
        Task<OrderViewDto> GetById(int id);
        Task<OrderViewDto> Create(OrderDto orderCreate);
        Task<OrderViewDto> Update(int id, OrderUpdateDto orderUpdate);
        Task<bool> Delete(int id);
    }
}