using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.DTOs.OrderDto;
using InventorySys.Models;

namespace InventorySys.Interfaces
{
    public interface IOrderRepo
    {
        public Task<Order> CreateEmptyOrder(string UserId);

        public Task<Order> AddOrderItemAsync(int orderId , OrderItemDto orderItemdto);
        public Task<List<Order>> GetOrdersAsync(String UserId);
        public Task<Order> GetOrderByIdAsync(int orderId);
        public Task<Order> CompleteOrderAsync(int orderId);
    }
}