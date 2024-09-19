using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.Data;
using InventorySys.DTOs.OrderDto;
using InventorySys.Interfaces;
using InventorySys.Mapper;
using InventorySys.Models;
using Microsoft.EntityFrameworkCore;

namespace InventorySys.Repositories
{
    public class OrderRepo : IOrderRepo
    
    {
        private readonly ApplicationDbContext _context;

        public OrderRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        
        public async Task<Order> CreateEmptyOrder(string UserId)
        {
            var order = new Order
            {
                UserId = UserId,
                isCompleted = false,
                orderItems = new List<OrderItem>(),

            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> AddOrderItemAsync(int orderId, OrderItemDto orderItemdto)

        {
            
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            
            if (order == null)
            throw new Exception("Order not found");

            if (order.isCompleted)
            throw new Exception("Order is already completed");

            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == orderItemdto.ProductId);
            
            if (product == null || product.Quantity < orderItemdto.Quantity)
            throw new Exception("Product not found or insufficient quantity");

            orderItemdto.Price = product.Price;

            var orderItem = orderItemdto.ToOrderItemEntity();
            
            order.orderItems.Add(orderItem);
            product.Quantity -= orderItemdto.Quantity;

            await _context.SaveChangesAsync();

            return order;


        }

        public async Task<Order> CompleteOrderAsync(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);
            
            if (order == null)
            throw new Exception("Order not found");

            if (order.isCompleted)
            throw new Exception("Order is already completed");

            order.isCompleted = true;

            await _context.SaveChangesAsync();
            return order;
        }



        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
            .Include(o=>o.orderItems)
            .ThenInclude(o=>o.Product)
            .FirstOrDefaultAsync(o=> o.OrderId == orderId);
        }

        public async Task<List<Order>> GetOrdersAsync(string UserId)
        {
            return await _context.Orders
            .Where(o=>o.UserId == UserId)
            .Include(o=>o.orderItems)
            .ThenInclude(o=>o.Product)
            .ToListAsync();
        }
    }
}