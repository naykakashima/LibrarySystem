using Library.Application.DTO;
using Library.Domain.Roles;
using LibrarySystem;
using LibrarySystem.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Library.WebAPI.Controllers
{
    [ApiController]
    [Route("/")]
    public class DevController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index() => Ok("Library system backend is running!");

    }
}
