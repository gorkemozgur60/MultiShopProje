using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        public readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult> ContactList()
        {
            var values = await _contactService.GetAllContactAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> ContactGetById(string id)
        {
            var values = await _contactService.GetByIdContactAsync(id);
            return Ok(values);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> ContactDelete(string id)
        {
            await _contactService.DeleteContactAsync(id);
            return Ok("Mesaj Başarıyla Silindi");
        }
        [HttpPost]
        public async Task<ActionResult> ContactCreate(CreateContactDto createContactDto)
        {
            await _contactService.CreateContactAsync(createContactDto);
            return Ok("Mesaj Başarıyla Eklendi");
        }
        [HttpPut]
        public async Task<ActionResult> ContactUpdate(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContactAsync(updateContactDto);
            return Ok("Mesaj Başarıyla Güncellendi");
        }
    }
}
