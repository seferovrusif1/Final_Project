using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.ExperianceYearDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExperienceYearsController : ControllerBase
    {
        IExperienceYearService _service { get; }

        public ExperienceYearsController(IExperienceYearService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> CreateExperienceYearAsync(ExperienceYearCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}
