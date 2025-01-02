using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.BrandDtos;
using MultiShop.Catalog.Services.BrandServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult> BrandList()
        {
            var values = await _brandService.GetAllBrandAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> BrandyGetById(string id)
        {
            var values = await _brandService.GetByIdBrandAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> BrandDelete(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return Ok("Marka Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> BrandCreate(CreateBrand createBrandyDto)
        {
            await _brandService.CreateBrandAsync(createBrandyDto);
            return Ok("Marka Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> BrandUpdate(UpdateBrand updateBrand)
        {
            await _brandService.UpdateBrandAsync(updateBrand);
            return Ok("Marka Başarıyla Güncellendi");
        }
    }
}
