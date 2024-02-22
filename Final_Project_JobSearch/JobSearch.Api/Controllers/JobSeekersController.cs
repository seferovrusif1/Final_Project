using JobSearch.Business.DTOs.JobSeekerDTOs;
using JobSearch.Business.DTOs.SMJobSeekerDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekersController : ControllerBase
    {
        IJobSeekerService _service { get; }
        ISMJobSeekerService _addSMservice { get; }

        public JobSeekersController(IJobSeekerService service, ISMJobSeekerService addSMservice)
        {
            _service = service;
            _addSMservice = addSMservice;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateJobSeekerAsync(JobSeekerCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpPost("AddSocialMedia")]
        [Authorize]
        public async Task<IActionResult> AddSMJobSeekerAsync(SMJobSeekerCreateDTO dto)
        {
            await _addSMservice.AddSM(dto);
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

