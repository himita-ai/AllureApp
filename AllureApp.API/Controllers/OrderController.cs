using AllureApp.Core.Entities;
using AllureApp.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllureApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // api/order (User places order)
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder([FromBody] Order order)
        {
            var result = await _orderService.PlaceOrderAsync(order);
            return Ok(new { message = "Order placed successfully", data = result });
        }

        //  api/order (Admin only)
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        // api/order/user/{userId}
        [Authorize(Roles = "User,Admin")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var orders = await _orderService.GetOrdersByUserIdAsync(userId);
            return Ok(orders);
        }

        // api/order/{id}/status (Admin updates status)
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] string status)
        {
            var updated = await _orderService.UpdateOrderStatusAsync(id, status);
            if (!updated)
                return NotFound(new { message = "Order not found" });

            return Ok(new { message = $"Order status updated to {status}" });
        }
    }
}

