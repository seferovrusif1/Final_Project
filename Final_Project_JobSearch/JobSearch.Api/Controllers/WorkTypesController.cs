using JobSearch.Business.DTOs.SocialMediaDTOs;
using JobSearch.Business.DTOs.WorkTypeDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkTypesController : ControllerBase
    {
        IWorkTypeService _service { get; }

        public WorkTypesController(IWorkTypeService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> CreateWorkTypeAsync(WorkTypeCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}

