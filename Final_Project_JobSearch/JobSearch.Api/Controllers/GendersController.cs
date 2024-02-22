using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Business.DTOs.GenderDTOs;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        IGenderService _service { get; }

        public GendersController(IGenderService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
    [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateGenderAsync(GenderCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}
