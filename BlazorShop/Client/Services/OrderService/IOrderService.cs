using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.OrderService
{
    public interface IOrderService
    {
        Task<List<Order>> LoadOrders();
        Task PostOrder(Order order);
    }
}
