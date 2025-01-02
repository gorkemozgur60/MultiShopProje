
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services.Interface;
using System.Net;

namespace MultiShop.WebUI.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(HttpClient httpClient, IHttpContextAccessor httpContext)
        {
            _httpClient = httpClient;
            _httpContext = httpContext;
        }

        public async Task<UserDetailViewModel> GetUserInfo()
        {
            var values = await _httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
            return values;
        }
    }
}
