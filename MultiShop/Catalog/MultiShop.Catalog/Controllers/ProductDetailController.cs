using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        public readonly IProductDetailService _productDetailService;
        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<ActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> ProductDetailGetById(string id)
        {
            var values = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> ProductDetailDelete(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> ProductDetailCreate(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> ProductDetailUpdate(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Başarıyla Güncellendi");
        }
        [HttpGet("GetProductDetailByProductId/{id}")]
        public async Task<ActionResult> GetProductDetailByProductId(string id)
        {
            var values = await _productDetailService.GetByProductIdProductDetailAsync(id);
            return Ok(values);
        }
    }
}
