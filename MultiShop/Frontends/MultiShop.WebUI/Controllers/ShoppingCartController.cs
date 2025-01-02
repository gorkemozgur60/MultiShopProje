using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Areas.Admin.Services.BasketServices;
using MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        public ShoppingCartController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;
            _productService = productService;
        }

        public async Task<IActionResult> Index(string code, int discountRate , decimal totalNewPriceWithDiscount)
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            var values = await _basketService.GetBasket();

            if(values == null)
            {
                return RedirectToAction("Index", "Login");
            } 

            ViewBag.total = values.TotalPrice;
            var TotalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
            ViewBag.totalPriceWithTax = TotalPriceWithTax;
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.tax = tax;
            return View();
        }
        public async Task<IActionResult> AddBasketItem(string id)
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";

            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageURL
            };

            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");   
        }
        public async Task<IActionResult> RemoveBasketItems(string id)
        {
            await _basketService.RemoveBasket(id);
            return RedirectToAction("Index");
        }
    }
}
