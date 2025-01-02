using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.FeatureSliderServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class FeatureSliderController : ControllerBase
    {
        public readonly IFeatureSliderService _featureSliderService;

        public FeatureSliderController(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        [HttpGet]
        public async Task<ActionResult> FeatureSliderList()
        {
            var values = await _featureSliderService.GetAllFeautureSliderAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FeatureSlideryGetById(string id)
        {
            var values = await _featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> FeatureSliderDelete(string id)
        {
            await _featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne Çıkan Resim Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> FeatureSliderCreate(CreateFeatureSlider createFeatureSlideryDto)
        {
            await _featureSliderService.CreateFeautureSliderAsync(createFeatureSlideryDto);
            return Ok("Öne Çıkan Resim Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> FeatureSliderUpdate(UpdateFeatureSlider updateFeatureSlider)
        {
            await _featureSliderService.UpdateFeautureSliderAsync(updateFeatureSlider);
            return Ok("Öne Çıkan Resim Başarıyla Güncellendi");
        }
    }
}
