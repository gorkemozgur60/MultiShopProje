using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Route("Admin/Product")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IAdminProductService _productService;
        private readonly IAdminCategoryService _categoryService;
        public ProductController(IAdminProductService productService, IAdminCategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";

            var values = await _productService.GetProductsWithCategoryAsync();

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategoryDto()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";


            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün Ekleme İşlemleri";


            var values = await _categoryService.GetAllCategoryAsync();

            List<SelectListItem> categoryValues = (from x in values select new SelectListItem
            {
                Value = x.CategoryId,
                Text = x.CategoryName,
            }).ToList();

            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Güncelleme Sayfası";
            ViewBag.v0 = "Ürün İşlemleri";


            var values1 = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values1
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;

            


            var values = await _productService.GetByIdProductAsync(id);

            return View(values);
        }

        [HttpPost]
        [Route("UpdateProduct/{id}")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {

            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}
