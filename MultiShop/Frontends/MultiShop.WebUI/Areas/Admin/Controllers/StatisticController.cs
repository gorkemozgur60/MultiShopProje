using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Areas.Admin.Services.StatisticServices.UserStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly IAdminCatalogStatisticService _catalogStatisticService;
        private readonly IAdminCommentStatisticService _commentStatisticService;
        private readonly IAdminDiscountStatisticServices _discountStatisticService;
        private readonly IAdminMessageStatisticService _messageStatisticService;
        private readonly IAdminUserStatisticService _userStatisticService;

        public StatisticController(IAdminCatalogStatisticService catalogStatisticService, IAdminUserStatisticService userStatisticService, IAdminMessageStatisticService messageStatisticService, IAdminDiscountStatisticServices discountStatisticService, IAdminCommentStatisticService commentStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _messageStatisticService = messageStatisticService;
            _discountStatisticService = discountStatisticService;
            _commentStatisticService = commentStatisticService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            var productCount = await _catalogStatisticService.GetProductCount();
            var brandCount = await _catalogStatisticService.GetBrandCount();
            var productavg = await _catalogStatisticService.GetProductAvgCount();
            var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var minPriceProductName = await _catalogStatisticService.GetMinPriceProductName();

            var allCommentCount = await _commentStatisticService.GetTotalCommentCount();
            var activeCommentCount = await _commentStatisticService.GetActiveCommentCount();
            var passiveCommentCount = await _commentStatisticService.GetPassiveCommentCount();

            var messageCount = await _messageStatisticService.GetMessageCount();
            
            var discountCount = await _discountStatisticService.GetDiscountCouponCount();

            var userCount = await _userStatisticService.GetAllUserCount();


            if (categoryCount == null && productCount == null && brandCount == null && productavg == null && maxPriceProductName == null && minPriceProductName == null 
                && allCommentCount == null && activeCommentCount == null && passiveCommentCount == null && messageCount == null && discountCount == null && userCount == null)
            {
                return RedirectToAction("Index", "AdminLoginPanel", new { area = "Admin" });
            }


            ViewBag.CategoryCount = categoryCount;
            ViewBag.ProductCount = productCount;
            ViewBag.BrandCount = brandCount;
            ViewBag.Productavg = productavg;
            ViewBag.MaxPriceProductName = maxPriceProductName;
            ViewBag.MinPriceProductName = minPriceProductName;

            ViewBag.allCommentCount = allCommentCount;
            ViewBag.activeCommentCount = activeCommentCount;
            ViewBag.passiveCommentCount = passiveCommentCount;

            ViewBag.messageCount = messageCount;

            ViewBag.discountCount = discountCount;

            ViewBag.userCount = userCount;


            return View();
        }
    }
}
