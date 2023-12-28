using App.BUSINESS.DTOs.Brand;
using App.BUSINESS.DTOs.Category;
using App.BUSINESS.Services.Interfaces;
using App.CORE.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PhApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IValidator<CreateCategoryDto> _val;
        private readonly IValidator<UpdateCategoryDto> _valUpdate;

        public CategoryController(ICategoryService service, IValidator<CreateCategoryDto> val, IValidator<UpdateCategoryDto> valUpdate)
        {
            _service = service;
            _val = val;
            _valUpdate = valUpdate;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var brands = await _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, brands);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Category category = await _service.GetById(id);
            return StatusCode(StatusCodes.Status200OK, category);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCategoryDto createBrandDto)
        {
            var valResult = _val.Validate(createBrandDto);

            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Errors);
            }
            await _service.Create(createBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCategoryDto updateBrandDto)
        {
            var valResult = _valUpdate.Validate(updateBrandDto);

            if (!valResult.IsValid)
            {
                return BadRequest(valResult.Errors);
            }
            await _service.Update(updateBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete("id")]

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);

        }
    }
}
