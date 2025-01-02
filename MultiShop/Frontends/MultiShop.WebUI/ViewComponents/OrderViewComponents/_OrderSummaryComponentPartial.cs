using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Areas.Admin.Services.BasketServices;
using MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderSummaryComponentPartial : ViewComponent
    {
        private readonly IOrderAddressService _orderService;
        private readonly IBasketService _basketService;

        public _OrderSummaryComponentPartial(IOrderAddressService orderService, IBasketService basketService)
        {
            _orderService = orderService;
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _basketService.GetBasket();
            var totalPrice = (values.TotalPrice);
            var totalWithCategoryPrice = (values.TotalPrice + 20);
            ViewBag.totalPrice = totalPrice;
            ViewBag.totalWithCargoPrice = totalWithCategoryPrice;

            var basketItems = values.BasketItems;
            return View(basketItems);
        }
    }
}
