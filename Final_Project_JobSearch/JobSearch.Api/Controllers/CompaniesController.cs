using JobSearch.Business.DTOs.CompanyDTOs;
using JobSearch.Business.Services.Interfaces;
using JobSearch.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        ICompanyService _service { get; }

        public CompaniesController(ICompanyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        ///TODO: dto ile deyis
        public async Task<IActionResult> CreateCompanyAsync(CompanyCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}
