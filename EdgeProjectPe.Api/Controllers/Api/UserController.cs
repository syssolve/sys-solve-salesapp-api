using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EdgeProjectPe.Services.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EdgeProjectPe.Api.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);
            return Ok(result == null ? "Invalid User" : result);
        }
    }
}

