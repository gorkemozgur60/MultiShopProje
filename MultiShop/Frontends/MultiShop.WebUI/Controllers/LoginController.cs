using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
	{
		private readonly IIdentityService _identityService;

		public LoginController(IIdentityService identityService)
		{
			_identityService = identityService;
		}


		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(SignInDto signInDto)
		{
			if (!ModelState.IsValid)
			{
				return View(signInDto);
			}

			var values = await _identityService.SignIn(signInDto);

			if (!values)
			{
				ModelState.AddModelError("UsernameAndPasswordMismatch", "Kullanıcı adınızı veya şifreniz yanlış girdiniz.");
				return View();
			}
            return RedirectToAction("Index", "Default");
		}

	}
}
