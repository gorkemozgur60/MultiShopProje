using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/ProductDetails")]
    public class ProductDetailsController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public readonly IAdminProductDetailService _adminProductDetailService;

        public ProductDetailsController(IHttpClientFactory httpClientFactory, IAdminProductDetailService adminProductDetailService)
        {
            _httpClientFactory = httpClientFactory;
            _adminProductDetailService = adminProductDetailService;
        }

        [HttpGet]
        [Route("ProductDetail/{id}")]
        public async Task<IActionResult> ProductDetails(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürün Detayı";
            ViewBag.v3 = "Ürün Detayı Güncelleme Sayfası";
            ViewBag.v0 = "Ürün Detay İşlemleri";

            var values = await _adminProductDetailService.GetByProductIdProductDetailAsync(id);

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpPost]
        [Route("ProductDetail/{id}")]
        public async Task<IActionResult> ProductDetails(UpdateProductDetailDto updateProductDetailDto)
        {

            var values = await _adminProductDetailService.UpdateProductDetailAsync(updateProductDetailDto);

            if(values.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }

            return View();
        }
    }
}
