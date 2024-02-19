using JobSearch.Business.DTOs.PhoneDTOs;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        IPhoneService _service { get; }

        public PhonesController(IPhoneService service)
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
        public async Task<IActionResult> CreatePhoneAsync(PhoneCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}
