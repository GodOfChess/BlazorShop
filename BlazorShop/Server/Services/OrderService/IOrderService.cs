using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrders();
        Task PostOrder(Order order);
    }
}
