using AllureApp.Core.Entities;
using AllureApp.Repository.Interface;
using AllureApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;

        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public async Task<Order> PlaceOrderAsync(Order order)
        {
            return await _orderRepo.AddOrderAsync(order);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _orderRepo.GetAllOrdersAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _orderRepo.GetOrdersByUserIdAsync(userId);
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _orderRepo.GetOrderByIdAsync(id);
        }

        public async Task<bool> UpdateOrderStatusAsync(int id, string status)
        {
            return await _orderRepo.UpdateOrderStatusAsync(id, status);
        }
    }
}
