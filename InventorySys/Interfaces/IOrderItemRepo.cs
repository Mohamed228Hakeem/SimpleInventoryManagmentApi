using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.Models;

namespace InventorySys.Interfaces
{
    public interface IOrderItemRepo
    {
        public Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        public Task<List<OrderItem>> GetAllOrderItemsAsync();
    }
}