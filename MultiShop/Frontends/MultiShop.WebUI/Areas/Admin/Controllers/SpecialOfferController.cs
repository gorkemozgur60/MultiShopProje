using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly IAdminSpecialOfferService _specialOfferService;
        private readonly IAdminCategoryService _categoryService;

        public SpecialOfferController(IAdminSpecialOfferService specialOfferService, IAdminCategoryService categoryService)
        {
            _specialOfferService = specialOfferService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Görseller";
            ViewBag.v3 = "Özel Görsel Listesi";
            ViewBag.v0 = "Özel Görsel İşlemleri";

            var values = await _specialOfferService.GetAllSpecialOfferAsync();

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Görseller";
            ViewBag.v3 = "Özel Görseller Listesi";
            ViewBag.v0 = "Özel Görseller Ekleme İşlemleri";

            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Görseller";
            ViewBag.v3 = "Özel Görseller Güncelleme Sayfası";
            ViewBag.v0 = "Özel Görseller İşlemleri";


            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateSpecialOffer/{id}")]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}
