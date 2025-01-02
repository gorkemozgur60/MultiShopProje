using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Areas.Admin.Services.BasketServices;
using MultiShop.WebUI.Services.BasketServices;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartDiscountCouponComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket();
            return View(values);
        }
    }
}
