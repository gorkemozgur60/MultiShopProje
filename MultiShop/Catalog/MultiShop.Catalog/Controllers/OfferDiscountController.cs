using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.OfferDiscountDtos;
using MultiShop.Catalog.Services.OfferDiscountServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class OfferDiscountController : ControllerBase
    {
        private readonly IOfferDiscountService _specialOfferService;

        public OfferDiscountController(IOfferDiscountService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<ActionResult> OfferDiscountList()
        {
            var values = await _specialOfferService.GetAllOfferDiscountAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> OfferDiscountyGetById(string id)
        {
            var values = await _specialOfferService.GetByIdOfferDiscountAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> OfferDiscountDelete(string id)
        {
            await _specialOfferService.DeleteOfferDiscountAsync(id);
            return Ok("İndirim Teklifi Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> OfferDiscountCreate(CreateOfferDiscount createOfferDiscountyDto)
        {
            await _specialOfferService.CreateOfferDiscountAsync(createOfferDiscountyDto);
            return Ok("İndirim Teklifi Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> OfferDiscountUpdate(UpdateOfferDiscount updateOfferDiscount)
        {
            await _specialOfferService.UpdateOfferDiscountAsync(updateOfferDiscount);
            return Ok("İndirim Teklifi Başarıyla Güncellendi");
        }
    }
}
