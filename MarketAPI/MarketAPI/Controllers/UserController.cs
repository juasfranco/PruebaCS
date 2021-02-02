using MarketAPI.Models.Request;
using MarketAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private InterfaceUserService _serviceUser;
        
        [HttpPost("login")]
        public IActionResult Authentify([FromBody] AuthRequest model)
        {
         
            return Ok(model);
        }
    }
}
