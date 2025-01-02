using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver.Core.WireProtocol.Messages;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using MultiShop.WebUI.Services.RegisterServices;
using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IRegisterService _registerService;

        public RegisterController(IHttpClientFactory httpClientFactory, IRegisterService registerService)
        {
            _httpClientFactory = httpClientFactory;
            _registerService = registerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createRegisterDto);
            }

			var values = await _registerService.CreateRegister(createRegisterDto);


			if (values.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }

            if (!values.IsSuccessStatusCode)
            {
				var errorMessage = await values.Content.ReadAsStringAsync();
				ModelState.AddModelError(string.Empty, errorMessage);
				return View(createRegisterDto);
			}

            return View();

        }
    }
}
