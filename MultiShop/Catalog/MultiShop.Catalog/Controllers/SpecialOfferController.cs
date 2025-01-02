using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.SpecialOfferDtos;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferService _specialOfferService;

        public SpecialOfferController(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        [HttpGet]
        public async Task<ActionResult> SpecialOfferList()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> SpecialOfferyGetById(string id)
        {
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> SpecialOfferDelete(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            return Ok("Özel Resim Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> SpecialOfferCreate(CreateSpecialOffer createSpecialOfferyDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferyDto);
            return Ok("Özel Resim Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> SpecialOfferUpdate(UpdateSpecialOffer updateSpecialOffer)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOffer);
            return Ok("Özel Resim Başarıyla Güncellendi");
        }
    }
}
