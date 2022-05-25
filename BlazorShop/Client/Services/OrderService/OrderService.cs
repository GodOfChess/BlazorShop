using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorShop.Client.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> LoadOrders()
        {
            return await _httpClient.GetFromJsonAsync<List<Order>>("api/Order");
        }

        public async Task PostOrder(Order order)
        {
            await _httpClient.PostAsJsonAsync("api/Order", order);
        }
    }
}
