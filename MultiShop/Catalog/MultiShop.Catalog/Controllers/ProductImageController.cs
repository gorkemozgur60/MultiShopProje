using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    
    public class ProductImageController : ControllerBase
    {
        public readonly IProductImageService _productImageService;
        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<ActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> ProductImageGetById(string id)
        {
            var values = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> ProductImageDelete(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün Görseli Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> ProductImageCreate(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün Görseli Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> ProductImageUpdate(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün Görseli Başarıyla Güncellendi");
        }
        [HttpGet("ProductImageByProductId/{id}")]
        public async Task<ActionResult> ProductImageByProductId(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }
    }
}

