using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/OfferDiscount")]
    public class OfferDiscountController : Controller
    {
        private readonly IAdminOfferDiscountService _offerDiscountService;

        public OfferDiscountController(IAdminOfferDiscountService offerDiscountService)
        {
            _offerDiscountService = offerDiscountService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklif";
            ViewBag.v3 = "Özel Teklif Listesi";
            ViewBag.v0 = "Özel Teklif İşlemleri";

            var values = await _offerDiscountService.GetAllOfferDiscountAsync();

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpGet]
        [Route("CreateOfferDiscount")]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklif";
            ViewBag.v3 = "Özel Teklif Listesi";
            ViewBag.v0 = "Özel Teklif Ekleme İşlemleri";

            return View();
        }

        [HttpPost]
        [Route("CreateOfferDiscount")]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [Route("DeleteOfferDiscount/{id}")]
        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            await _offerDiscountService.DeleteOfferDiscountAsync(id);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklif";
            ViewBag.v3 = "Özel Teklif Güncelleme Sayfası";
            ViewBag.v0 = "Özel Teklif İşlemleri";

            var values = await _offerDiscountService.GetByIdOfferDiscountAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateOfferDiscount/{id}")]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
            return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
        }
    }
}
