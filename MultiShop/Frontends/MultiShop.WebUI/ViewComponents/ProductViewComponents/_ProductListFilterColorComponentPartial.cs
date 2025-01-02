using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductViewComponents
{
    public class _ProductListFilterColorComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
        return View(); 
        }
    }
}
