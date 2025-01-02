using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatictisController : ControllerBase
    {
        private readonly IStaticticService _staticticService;

        public StatictisController(IStaticticService staticticService)
        {
            _staticticService = staticticService;
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _staticticService.GetBrandCount();
            return Ok(values);
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var values = await _staticticService.GetCategoryCount();
            return Ok(values);
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var values = await _staticticService.GetProductCount();
            return Ok(values);
        }

        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var values = await _staticticService.GetProductAvgCount();
            return Ok(values);
        }

        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var values = await _staticticService.GetMaxPriceProductName();
            return Ok(values);
        }

        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var values = await _staticticService.GetMinPriceProductName();
            return Ok(values);
        }
    }
}
