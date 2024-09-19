using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InventorySys.DTOs.OrderDto;
using InventorySys.Extenstions;
using InventorySys.Interfaces;
using InventorySys.Mapper;
using InventorySys.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventorySys.Controllers
{   
    [ApiController]
    [Route("api/OrderManagement")]
    [Authorize]

    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<OrdersController> _logger;
        public OrdersController(IOrderRepo orderRepo, UserManager<AppUser> userManager, ILogger<OrdersController> logger)
        {
            _orderRepo = orderRepo;
            _userManager = userManager;
            _logger = logger;

        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder()
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            _logger.LogInformation("User Id: {UserId}", userId);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(); // Or BadRequest based on your logic
        }
            

            var createorder = await _orderRepo.CreateEmptyOrder(userId);

            return Ok ($"Order Created Successfully , Order Id: {createorder.OrderId}");

        }


        [HttpPost("{orderId}/AddOrderItems")]
        public async Task<IActionResult> AddOrderItemAsync(int orderId, [FromBody]OrderItemDto orderItemdto)
        {
            
            var updatedOrder = await _orderRepo.AddOrderItemAsync(orderId, orderItemdto);
            return Ok(updatedOrder.ToOrderDto());
        }

        [HttpPost("{orderId}/CompleteOrder")]
        public async Task<IActionResult> CompleteOrder(int orderId)
        {
            var CompleteOrder = await _orderRepo.CompleteOrderAsync(orderId);
            return Ok(CompleteOrder.ToOrderDto());
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderRepo.GetOrderByIdAsync(orderId);

            if (order.orderItems.Capacity == 0)
            {
                return Ok(order.ToEmptyOrderDTO());
            }
            return Ok(order.ToOrderDto());
        }
    }
}