using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using MultiShop.WebUI.Areas.Admin.Services.BasketServices;
using MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.Interface;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderService;
        private readonly IBasketService _basketService;
        private readonly IUserService _userService;

        public OrderController(IOrderAddressService orderService, IBasketService basketService, IUserService userService)
        {
            _orderService = orderService;
            _basketService = basketService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "Anasayfa";
            ViewBag.directory2 = "Sipariş";
            ViewBag.directory3 = "Sipariş Detayı";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;
            createOrderAddressDto.Description = "aaa";
            await _orderService.CreateOrderAddressAsync(createOrderAddressDto);
            return RedirectToAction("Index","Payments");
        }

		[HttpGet]
		public PartialViewResult OrderSummaryTotalPrice()
		{
			return PartialView();
		}
	}
}
