using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopFolio.Api.DAL;
using ShopFolio.Api.Models;
using ShopFolio.Api.Services;
using ShopFolio.Api.ViewModels;

namespace ShopFolio.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly ShopFolioDbContext context;
        private readonly IConfiguration configuration;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ShopFolioDbContext context, IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.context = context;
            this.configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginViewModel loginViewModel)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == loginViewModel.UserName.ToUpper());
            if (user == null)
                return StatusCode(StatusCodes.Status404NotFound, "User not found");
            var passCheckResult = await signInManager.CheckPasswordSignInAsync(user, loginViewModel.Password, false);
            if (passCheckResult == Microsoft.AspNetCore.Identity.SignInResult.Success)
            {
                //TODO:Generate JWT
                var acc_service = new AccountsService(configuration);
                return Ok(acc_service.CreateJwtToken(loginViewModel.UserName));
            }
            else
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Incorrect Password");
            }

        }
        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> Register([FromBody] RegisterViewModel registerViewModel)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == registerViewModel.Email.ToUpper()
            || u.NormalizedUserName == registerViewModel.UserName.ToUpper());
            if (user != null)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Email or UserName already in use.");
            }
            else
            {
                var userToBeRegistred = new AppUser
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email
                };
                var registerResult = await userManager.CreateAsync(userToBeRegistred, registerViewModel.Password);
                if (registerResult == Microsoft.AspNetCore.Identity.IdentityResult.Success)
                {
                    var acc_service = new AccountsService(configuration);
                    return Ok(acc_service.CreateJwtToken(registerViewModel.UserName));
                }
                else
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, registerResult.Errors);
                }
            }
        }
    }
}