using JobSearch.Business.DTOs.CityDTOs;
using JobSearch.Business.DTOs.SocialMediaDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        ISocialMediaService _service { get; }

        public SocialMediasController(ISocialMediaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> CreateSMAsync(SocialMediaCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}

