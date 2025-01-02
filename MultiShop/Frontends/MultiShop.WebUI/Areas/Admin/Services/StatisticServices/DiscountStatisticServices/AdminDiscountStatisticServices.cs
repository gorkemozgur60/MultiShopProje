using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.DiscountStatisticServices
{
    public class AdminDiscountStatisticServices : IAdminDiscountStatisticServices
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminDiscountStatisticServices(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<int?> GetDiscountCouponCount()
        {
            var response = await _httpClient.GetAsync("discount/getdiscountcouponcount");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<int>("discount/getdiscountcouponcount");
            return values;
        }
    }
}
