using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.FeatureDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;
using MultiShop.Catalog.Services.FeatureServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public async Task<ActionResult> FeatureSliderList()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> FeatureGetById(string id)
        {
            var values = await _featureService.GetByIdFeatureAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> FeatureDelete(string id)
        {
            await _featureService.DeleteFeatureAsync(id);
            return Ok("Öne Çıkan Icon Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> FeatureCreate(CreateFeature createFeatureDto)
        {
            await _featureService.CreateFeatureAsync(createFeatureDto);
            return Ok("Öne Çıkan Icon Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> FeatureUpdate(UpdateFeature updateFeature)
        {
            await _featureService.UpdateFeatureAsync(updateFeature);
            return Ok("Öne Çıkan Icon Başarıyla Güncellendi");
        }
    }
}
