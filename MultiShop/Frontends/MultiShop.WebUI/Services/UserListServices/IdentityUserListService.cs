using MultiShop.DtoLayer.IdentityDtos.UserListDtos;

namespace MultiShop.WebUI.Services.IdentityUserLİstServices
{
    public class IdentityUserListService : IIdentityUserListService
    {
        private readonly HttpClient _httpClient;

        public IdentityUserListService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultUserListDto>> GetUserListAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultUserListDto>>("users/GetAllUserList");
            return values;
        }
    }
}
