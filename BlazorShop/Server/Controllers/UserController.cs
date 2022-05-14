using BlazorShop.Server.Services.UserService;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;

        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpPost("loguser")]
        public async Task<IActionResult> LogUser(User user)
        {
            var response = _userservice.LoginUser(user);
            if (response.Result == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("checkuser")]
        public async Task<IActionResult> CheckUser(User user)
        {
            var response = _userservice.CheckAdmin(user);
            if (response.Result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegUser(User user)
        {
            var response = _userservice.RegisterUser(user);
            if (response.Result == false)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _userservice.GetAllUsers());
        }
    }
}
