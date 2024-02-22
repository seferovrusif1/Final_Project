using JobSearch.Business.DTOs.VacancyDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        IVacancyService _service { get; }

        public VacanciesController(IVacancyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateVacancyAsync(VacancyCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPut("SoftDelete")]
        [Authorize]
        public async Task<IActionResult> SoftDeleteCompanyAsync(int id)
        {
            await _service.SoftDelete(id);
            return Ok();
        }
        [HttpPut("ReverseSoftDelete")]
        [Authorize]
        public async Task<IActionResult> ReverseSoftDeleteCompanyAsync(int id)
        {
            await _service.ReverseSoftDelete(id);
            return Ok();
        }
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}

