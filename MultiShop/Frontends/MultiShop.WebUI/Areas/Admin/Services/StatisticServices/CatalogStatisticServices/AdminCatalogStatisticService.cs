using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.CatalogStatisticServices
{
    public class AdminCatalogStatisticService : IAdminCatalogStatisticService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminCatalogStatisticService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<long?> GetBrandCount()
        {
            var response = await _httpClient.GetAsync("Statictis/GetBrandCount");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<long>("Statictis/GetBrandCount");
            return values;
        }

        public async Task<long?> GetCategoryCount()
        {
            var response = await _httpClient.GetAsync("Statictis/GetCategoryCount");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<long>("Statictis/GetCategoryCount");
            return values;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var responsee = await _httpClient.GetAsync("Statictis/GetMaxPriceProductName");

            if (responsee.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var response = await _httpClient.GetStringAsync("Statictis/GetMaxPriceProductName");
            return response;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var responsee = await _httpClient.GetAsync("Statictis/GetMinPriceProductName");

            if (responsee.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var response = await _httpClient.GetStringAsync("Statictis/GetMinPriceProductName");
            return response;
        }

        public async Task<decimal?> GetProductAvgCount()
        {
            var responsee = await _httpClient.GetAsync("Statictis/GetProductAvgPrice");

            if (responsee.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<decimal>("Statictis/GetProductAvgPrice");
            return values;
        }

        public async Task<long?> GetProductCount()
        {
            var responsee = await _httpClient.GetAsync("Statictis/GetProductCount");

            if (responsee.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<long>("Statictis/GetProductCount");
            return values;
        }
    }
}
