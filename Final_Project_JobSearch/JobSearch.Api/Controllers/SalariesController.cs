using JobSearch.Business.DTOs.CityDTOs;
using JobSearch.Business.DTOs.SalaryDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        ISalaryService _service { get; }

        public SalariesController(ISalaryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        ///TODO: dto ile deyis
        public async Task<IActionResult> CreateCityAsync(SalaryCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}

