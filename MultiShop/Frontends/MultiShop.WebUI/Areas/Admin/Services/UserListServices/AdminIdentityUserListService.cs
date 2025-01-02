using MultiShop.DtoLayer.IdentityDtos.UserListDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.UserListServices
{
    public class AdminIdentityUserListService : IAdminIdentityUserListService
    {
        private readonly HttpClient _httpClient;

        public AdminIdentityUserListService(HttpClient httpClient)
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
