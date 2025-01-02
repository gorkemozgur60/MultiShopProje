
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.RegisterServices
{
    public class RegisterService : IRegisterService
    {
        private readonly HttpClient _httpClient;

        public RegisterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> CreateRegister(CreateRegisterDto createRegisterDto)
        {
            var values = await _httpClient.PostAsJsonAsync<CreateRegisterDto>("registers/userregister", createRegisterDto);

			if (!values.IsSuccessStatusCode)
			{
				await values.Content.ReadAsStringAsync();
			}
			return values;
        }
    }
}
