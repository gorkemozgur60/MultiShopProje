using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly IAdminProductImageService _productImageService;

        public ProductImageController(IHttpClientFactory httpClientFactory, IAdminProductImageService productImageService)
        {
            _httpClientFactory = httpClientFactory;
            _productImageService = productImageService;
        }

        [HttpGet]
        [Route("ProductImageDetail/{id}")]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Görseller";
            ViewBag.v3 = "Ürün Görseller Güncelleme Sayfası";
            ViewBag.v0 = "Ürün Görseller İşlemleri";

            var values = await _productImageService.GetByProductIdProductImageAsync(id);

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpPost]
        [Route("ProductImageDetail/{id}")]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
            
        }
    }
}
