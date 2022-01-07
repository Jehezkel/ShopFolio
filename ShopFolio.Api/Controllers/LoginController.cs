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

        public LoginController()
        {
        }
<<<<<<< HEAD
        // [AllowAnonymous]
        // [HttpPost]
        // public IActionResult Login(){
            
        // }
=======
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel){
            throw new NotImplementedException();
        }
>>>>>>> 63792c25dbc6da393abc8d6ad29b91b1a8e9b9fd
    }
}