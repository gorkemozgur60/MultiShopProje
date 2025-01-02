using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ContactServices;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "Anasayfa";
            ViewBag.directory2 = "İletişim";
            ViewBag.directory3 = "Mesaj Gönder";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendTime = DateTime.Now;

            var values = await _contactService.CreateContactAsync(createContactDto);

            if(values == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction("Index", "Default");
        }

        
    }
}
