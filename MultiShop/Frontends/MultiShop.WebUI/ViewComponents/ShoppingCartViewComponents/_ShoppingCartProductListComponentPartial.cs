using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Areas.Admin.Services.BasketServices;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.Interface;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        public _ShoppingCartProductListComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket();
            var basketitems = values.BasketItems;
            return View(basketitems);
        }
    }
}
