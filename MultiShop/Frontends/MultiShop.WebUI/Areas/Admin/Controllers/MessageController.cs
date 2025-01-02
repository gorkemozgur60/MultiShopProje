using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ContactServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Message")]
    public class MessageController : Controller
    {
        private readonly IAdminContactService _contactService;

        public MessageController(IAdminContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _contactService.GetAllContactAsync();

            if(values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new {area = "Admin"});
            }

            return View(values);
        }

        [HttpGet]
        [Route("ContactDetail/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var values = await _contactService.GetByIdContactAsync(id);

            if (values == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }

            return View(values);
        }
    }
}
