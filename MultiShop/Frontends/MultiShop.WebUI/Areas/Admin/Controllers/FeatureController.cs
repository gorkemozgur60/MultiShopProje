using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Feature")]
    public class FeatureController : Controller
    {
        private readonly IAdminFeatureService _featureService;

        public FeatureController(IAdminFeatureService featureService)
        {
            _featureService = featureService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkanlar Listesi";
            ViewBag.v0 = "Öne Çıkanlar İşlemleri";

            var values = await _featureService.GetAllFeatureAsync();

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpGet]
        [Route("CreateFeature")]
        public IActionResult CreateFeature()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkanlar Listesi";
            ViewBag.v0 = "Öne Çıkanlar Ekleme İşlemleri";

            return View();
        }

        [HttpPost]
        [Route("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }

        [Route("DeleteFeature/{id}")]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });

        }

        [HttpGet]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.v3 = "Öne Çıkanlar Güncelleme Sayfası";
            ViewBag.v0 = "Öne Çıkanlar İşlemleri";

            var values = await _featureService.GetByIdFeatureAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateFeature/{id}")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureService.UpdateFeatureAsync(updateFeatureDto);
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        }
    }
}
