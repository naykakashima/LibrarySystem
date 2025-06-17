using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Library.Application.DTO;
using Library.Application.Interfaces;
using System.Diagnostics;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController (IAuthService authService )
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            try
            {
                var newUser = await _authService.RegisterUserAsync(dto);
                return Ok(new
                {
                    newUser.Id,
                    newUser.Email,
                    newUser.Username,
                });

            }
            catch (Exception ex) 
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
}
