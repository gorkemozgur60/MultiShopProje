

using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.MessageStatisticServices
{
    public class AdminMessageStatisticService : IAdminMessageStatisticService
	{
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminMessageStatisticService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int?> GetMessageCount()
        {
            var response = await _httpClient.GetAsync("UserMessage/GetMessageCount");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<int>("UserMessage/GetMessageCount");
            return values;
        }
    }
}
