using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.Data;
using InventorySys.Interfaces;
using InventorySys.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySys.Repositories
{
    public class OrderItemRepo : IOrderItemRepo
    {
        private readonly ApplicationDbContext _context;
        public OrderItemRepo(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();
            return orderItem;
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _context.OrderItems.ToListAsync();
        }
    }
}