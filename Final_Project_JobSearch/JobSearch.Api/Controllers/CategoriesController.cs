﻿using JobSearch.Business.DTOs.CategoryDTOs;
using JobSearch.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _service { get; }

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoryAsync(CategoryCreateDTO dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
    }
}

