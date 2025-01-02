using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    //[Authorize]
    [AllowAnonymous]
	[Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult> CategoryList()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> CategoryGetById(string id)
        {
            var values = await _categoryService.GetByIdCategoriesAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> CategoryDelete(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> CategoryCreate(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> CategoryUpdate(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori Başarıyla Güncellendi");
        }
    }
}
