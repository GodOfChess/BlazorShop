using BlazorShop.Server.Services.LinkService;
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
    public class LinkController : ControllerBase
    {
        private readonly ILinkService _linkService;

        public LinkController(ILinkService linkservice)
        {
            _linkService = linkservice;
        }

        [HttpGet("{productName}")]
        public async Task<ActionResult<List<Link>>> GetLinksByProductFromDB(string productName)
        {
            return Ok(await _linkService.GetLinksByProduct(productName));
        }

        [HttpGet]
        public async Task<ActionResult<List<Link>>> GetLinksFromDB()
        {
            return Ok(await _linkService.GetLinks());
        }

        [HttpPost]
        public async Task<IActionResult> PostLinkToDB(Link link)
        {
            await _linkService.PostLink(link);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinkFromDB(int id)
        {
            await _linkService.DeleteLink(id);
            return Ok();
        }
    }
}
