using JobSearch.Business.DTOs.AuthDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        IAppUserService _userservice { get; }
        public AppUsersController(IAppUserService userservice)
        {
            _userservice = userservice;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            await _userservice.CreateAsync(dto);
            return Ok(dto);
        }

    }
}
