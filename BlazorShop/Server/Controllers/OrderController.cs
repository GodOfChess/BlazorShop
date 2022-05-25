using BlazorShop.Server.Services.OrderService;
using BlazorShop.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService productservice)
        {
            _orderService = productservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            return Ok(await _orderService.GetOrders());
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderToDB(Order order)
        {
            await _orderService.PostOrder(order);
            return Ok();
        }
    }
}
