using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<ActionResult> AboutList()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> AboutyGetById(string id)
        {
            var values = await _aboutService.GetByIdAboutAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> AboutDelete(string id)
        {
            await _aboutService.DeleteAboutAsync(id);
            return Ok("Hakkımda Bilgisi Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> AboutCreate(CreateAbout createAboutDto)
        {
            await _aboutService.CreateAboutAsync(createAboutDto);
            return Ok("Hakkımda Bilgisi Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> AboutUpdate(UpdateAbout updateAbout)
        {
            await _aboutService.UpdateAboutAsync(updateAbout);
            return Ok("Hakkımda Bilgisi Başarıyla Güncellendi");
        }
    }
}
