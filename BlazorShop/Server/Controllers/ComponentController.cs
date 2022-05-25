using BlazorShop.Server.Services.ComponentService;
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
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;

        public ComponentController(IComponentService componentservice)
        {
            _componentService = componentservice;
        }

        [HttpGet]
        public async Task<ActionResult<List<Component>>> GetAllComponents()
        {
            return Ok(await _componentService.GetComponents());
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderToDB(Component component)
        {
            await _componentService.PostComponent(component);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentFromDB(int id)
        {
            await _componentService.DeleteComponent(id);
            return Ok();
        }
    }
}
