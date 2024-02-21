using JobSearch.Business.DTOs.TypeOfVacancyDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesOfVacancyController : ControllerBase
    {
        ITypeOfvacancyService _service { get; }

        public TypesOfVacancyController(ITypeOfvacancyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> CreateTypeOfVacancyAsync(TypeOfVacancyCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}

