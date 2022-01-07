using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopFolio.Api.ViewModels;

namespace ShopFolio.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration config;

        public LoginController(IConfiguration config)
        {
            this.config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel){
            throw new NotImplementedException();
        }
    }
}