using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAdminAboutService _aboutService;

        public AboutController(IAdminAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _aboutService.GetAllAboutAsync();

            if(values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkındaler";
            ViewBag.v3 = "Hakkındaler Listesi";
            ViewBag.v0 = "Hakkındaler Ekleme İşlemleri";

            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkındaler";
            ViewBag.v3 = "Hakkındaler Güncelleme Sayfası";
            ViewBag.v0 = "Hakkındaler İşlemleri";


            var values = await _aboutService.GetByIdAboutAsync(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }
    }
}
