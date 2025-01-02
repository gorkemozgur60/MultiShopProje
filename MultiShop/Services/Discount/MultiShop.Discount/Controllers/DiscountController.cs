using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await _discountService.GetAllCouponsAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountService.GetByIdCouponAsync(id);
            return Ok(values);
        }
        [HttpGet("GetCodeDetailByCode")]
        public async Task<IActionResult> GetCodeDetailByCode(string code)
        {
            var values = await _discountService.GetCodeDetailByCode(code);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateCoupon createCoupon)
        {
            await _discountService.CreateCouponAsync(createCoupon);
            return Ok("Kupon başarıyla oluşturuldu");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountService.DeleteCouponAsync(id);
            return Ok("Kupon Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateCoupon updateCoupon)
        {
            await _discountService.UpdateCouponAsync(updateCoupon);
            return Ok("Kupon Başarıyla Güncellendi");
        }
        [HttpGet("GetDiscountCouponCountRate")]
        public  IActionResult GetDiscountCouponCountRate(string code)
        {
            var values = _discountService.GetDiscountCouponCountRate(code);
            return Ok(values);
        }

        [HttpGet("GetDiscountCouponCount")]
        public async Task<IActionResult> GetDiscountCouponCount()
        {
            var values = await _discountService.GetDiscountCouponCount();
            return Ok(values);
        }
    }
}
