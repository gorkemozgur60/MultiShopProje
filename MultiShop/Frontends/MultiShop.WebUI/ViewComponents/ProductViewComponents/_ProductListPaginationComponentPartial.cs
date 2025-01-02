using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ProductViewComponents
{
    public class _ProductListPaginationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

        return View(); 
        }
    }
}
