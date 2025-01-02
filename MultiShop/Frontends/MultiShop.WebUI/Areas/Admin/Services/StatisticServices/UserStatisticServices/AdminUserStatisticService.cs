using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.UserStatisticServices
{
    public class AdminUserStatisticService : IAdminUserStatisticService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminUserStatisticService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int?> GetAllUserCount()
        {
            var response = await _httpClient.GetAsync("statistics/getallusercount");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }
            var values = await _httpClient.GetFromJsonAsync<int>("statistics/getallusercount");
            return values;
        }
    }
}
