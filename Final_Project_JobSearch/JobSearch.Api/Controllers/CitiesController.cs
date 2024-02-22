using JobSearch.Business.DTOs.CityDTOs;
using JobSearch.Business.DTOs.ExperianceYearDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        ICityService _service { get; }

        public CitiesController(ICityService service)
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
        public async Task<IActionResult> CreateCityAsync(CityCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}

