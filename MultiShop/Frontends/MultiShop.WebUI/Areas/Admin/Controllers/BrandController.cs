using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IAdminBrandService _brandService;

        public BrandController(IAdminBrandService brandService)
        {
            _brandService = brandService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markaler";
            ViewBag.v3 = "Marka Listesi";
            ViewBag.v0 = "Marka İşlemleri";

            var values = await _brandService.GetAllBrandAsync();

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markaler";
            ViewBag.v3 = "Markaler Listesi";
            ViewBag.v0 = "Markaler Ekleme İşlemleri";

            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await _brandService.CreateBrandAsync(createBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await _brandService.DeleteBrandAsync(id);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Markaler";
            ViewBag.v3 = "Markaler Güncelleme Sayfası";
            ViewBag.v0 = "Markaler İşlemleri";

            var values = await _brandService.GetByIdBrandAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await _brandService.UpdateBrandAsync(updateBrandDto);
            return RedirectToAction("Index", "Brand", new { area = "Admin" });
        }
    }
}
