using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.FeatureSliderServices;



namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private readonly IAdminFeatureSliderService _featureSliderService;

        public FeatureSliderController(IAdminFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Görseller";
            ViewBag.v3 = "Görsel Listesi";
            ViewBag.v0 = "Görsel İşlemleri";

            var values = await _featureSliderService.GetAllFeautureSliderAsync();

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpGet]
        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Görseller";
            ViewBag.v3 = "Görsel Listesi";
            ViewBag.v0 = "Görsel Ekleme İşlemleri";

            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await _featureSliderService.CreateFeautureSliderAsync(createFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Görseller";
            ViewBag.v3 = "Görsel Güncelleme Sayfası";
            ViewBag.v0 = "Görsel İşlemleri";
          

            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateFeatureSlider/{id}")]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await _featureSliderService.UpdateFeautureSliderAsync(updateFeatureSliderDto);
            return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
        }
    }
}
