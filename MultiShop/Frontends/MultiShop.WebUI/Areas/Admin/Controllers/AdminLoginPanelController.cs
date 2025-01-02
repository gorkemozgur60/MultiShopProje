using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Services.Interface;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/AdminLoginPanel")]
	public class AdminLoginPanelController : Controller
	{

		private readonly IIdentityService _identityService;

		public AdminLoginPanelController(IIdentityService identityService)
		{
			_identityService = identityService;
		}

		[Route("Index")]
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[Route("Index")]
		[HttpPost]
		public async Task<IActionResult> Index(SignInDto signInDto)
		{
			if (!ModelState.IsValid)
			{
				return View(signInDto);
			}

			var values = await _identityService.SignInAdminPanel(signInDto);

			if (!values)
			{
				ModelState.AddModelError("UsernameAndPasswordMismatch", "Kullanıcı adınızı veya şifreniz yanlış girdiniz.");
				return View();
			}
			return RedirectToAction("Index", "Category", new { area = "Admin" });
		}
	}
}
