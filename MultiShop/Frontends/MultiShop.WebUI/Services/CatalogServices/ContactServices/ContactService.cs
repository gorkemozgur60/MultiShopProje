

using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using System.Net;

namespace MultiShop.WebUI.Services.CatalogServices.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public ContactService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task<HttpResponseMessage> CreateContactAsync(CreateContactDto createContactDto)
        {
            var response = await _httpClient.GetAsync("contact");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _contextAccessor.HttpContext.Response.Redirect("Login/Index");
                return null;
            }

            var values = await _httpClient.PostAsJsonAsync<CreateContactDto>("contact", createContactDto);
            return values;
        }

        public async Task DeleteContactAsync(string id)
        {
            await _httpClient.DeleteAsync("contact/" + id);
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultContactDto>>("contact");
            return values;
        }

        public async Task<GetByContactDto> GetByIdContactAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<GetByContactDto>("contact/"+id);
            return values;
        }

        public async Task UpdateContactAsync(UpdateContactDto updateContactDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateContactDto>("contact", updateContactDto);
        }
    }
}
