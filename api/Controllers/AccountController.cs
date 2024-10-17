using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Controllers.Dtos.Account;
using api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _UserMananger;
        public AccountController (UserManager<AppUser> userManager)
        {
            _UserMananger = userManager;

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterDto register)
        {

            try
            {
                 if(!ModelState.IsValid)
                    return BadRequest(ModelState);

                var AppUser = new AppUser
                {
                    UserName = register.Username,
                    Email = register.Email
                };

                var createdUser = await _UserMananger.CreateAsync(AppUser,register.Password);

                if(createdUser.Succeeded)
                {
                    var roleResult = await _UserMananger.AddToRoleAsync(AppUser,"User");
                    if(roleResult.Succeeded)
                    {
                        return Ok("User Created");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch(Exception e)
            {
                 return StatusCode(500, e);
            }
        }
        
    }
}