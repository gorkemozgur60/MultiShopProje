using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.CommentStatisticServices
{
    public class AdminCommentStatisticService : IAdminCommentStatisticService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminCommentStatisticService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int?> GetActiveCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/GetPassiveCommentCount");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<int>("comments/GetPassiveCommentCount");
            return values;
        }

        public async Task<int?> GetPassiveCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/GetPassiveCommentCount");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<int>("comments/GetPassiveCommentCount");
            return values;
        }

        public async Task<int?> GetTotalCommentCount()
        {
            var response = await _httpClient.GetAsync("comments/GetPassiveCommentCount");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<int>("comments/GetPassiveCommentCount");
            return values;
        }
    }
}
