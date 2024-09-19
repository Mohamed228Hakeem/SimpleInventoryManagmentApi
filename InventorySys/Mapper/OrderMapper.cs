using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventorySys.DTOs.OrderDto;
using InventorySys.Models;

namespace InventorySys.Mapper
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
               OrderId = order.OrderId,
               UserId = order.UserId,
               isCompleted = order.isCompleted,
               
               OrderItems = order.orderItems.Select(i => new OrderItemDto
               {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Price * i.Quantity,
               }).ToList(),
                TotalPrice = order.orderItems.Sum(oi => oi.Price * oi.Quantity),
               
            };
        }

        public static Order ToOrderEntity(this OrderCreateDto orderDto)
    {
        return new Order
        {
           UserId = orderDto.UserId,
            isCompleted = false,
            orderItems = new List<OrderItem>()
        };
    }

    public static OrderItem ToOrderItemDto(this OrderItemDto orderItemDto)
    {
        return new OrderItem
        {
            
            ProductId = orderItemDto.ProductId,
            Quantity = orderItemDto.Quantity,
            Price = orderItemDto.Price
        };
    }

    public static OrderItem ToOrderItemEntity(this OrderItemDto orderItemDto)
    {
        return new OrderItem
        {
            // Note: You don't set OrderItemId here if it's auto-generated
            ProductId = orderItemDto.ProductId,
            Quantity = orderItemDto.Quantity,
            Price = orderItemDto.Price
        };
    }



    public static EmptyOrderDto ToEmptyOrderDTO  (this Order order)
    {
        return new EmptyOrderDto
        {
            OrderId = order.OrderId,
            UserId = order.UserId,
            isCompleted = order.isCompleted,
            
            Message = "Order is Currently Empty"
        };
    } 
    


    }
}