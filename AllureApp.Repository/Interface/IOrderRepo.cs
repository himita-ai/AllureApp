using AllureApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllureApp.Repository.Interface
{
    public interface IOrderRepo
    {
        Task<Order> AddOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
        Task<Order?> GetOrderByIdAsync(int id);
        Task<bool> UpdateOrderStatusAsync(int id, string status);
    }
}
