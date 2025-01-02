using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductViewComponents
{
    public class _ProductListGetProductCountComponentPartial : ViewComponent
    {
         public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
