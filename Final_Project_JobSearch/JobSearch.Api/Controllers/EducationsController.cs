using JobSearch.Business.DTOs.EducationDTOs;
using JobSearch.Business.DTOs.EmailDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        IEducationService _service { get; }

        public EducationsController(IEducationService service)
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
        public async Task<IActionResult> CreateEducationAsync(EducationCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}
