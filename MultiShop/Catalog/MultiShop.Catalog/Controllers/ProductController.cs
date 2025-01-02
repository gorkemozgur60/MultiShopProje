using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;


namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> ProductList()
        {
            var values =await _productService.GetAllProductAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> ProductGetById(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> ProductDelete(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Ürün Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> ProductCreate(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return Ok("Ürün Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> ProductUpdate(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün Başarıyla Güncellendi");
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productService.GetProductsWithCategoryAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategoryById/{id}")]
        public async Task<IActionResult> ProductListWithCategoryById(string id)
        {
            var values = await _productService.GetProductsWithCategoryByIdAsync(id);
            return Ok(values);
        }
    }
}
