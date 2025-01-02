using MultiShop.DtoLayer.CatalogDtos.ContactDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ContactServices
{
    public class AdminContactService : IAdminContactService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public AdminContactService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            await _httpClient.PostAsJsonAsync("contact", createContactDto);
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contact/" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var response = await _httpClient.GetAsync("contact");

            if (response == null)
            {
                _contextAccessor.HttpContext.Response.Redirect("/AdminLoginPanel/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("contact");
            return values;
        }

        public async Task<GetByContactDto> GetByIdContactAsync(string id)
        {
            var response = await _httpClient.GetAsync("contact");

            if (response == null)
            {
                _contextAccessor.HttpContext.Response.Redirect("/AdminLoginPanel/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<GetByContactDto>("contact/" + id);
            return values;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync("contact", updateContactDto);
        }
    }
}
