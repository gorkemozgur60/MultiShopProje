namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService : ICatalogStatisticService
    {
        private readonly HttpClient _httpClient;

        public CatalogStatisticService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long> GetBrandCount()
        {
            var values = await _httpClient.GetFromJsonAsync<long>("Statictis/GetBrandCount");
            return values;
        }

        public async Task<long> GetCategoryCount()
        {
            var values = await _httpClient.GetFromJsonAsync<long>("Statictis/GetCategoryCount");
            return values;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var response = await _httpClient.GetStringAsync("Statictis/GetMaxPriceProductName");
            return response;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var response = await _httpClient.GetStringAsync("Statictis/GetMaxPriceProductName");
            return response;
        }

        public async Task<decimal> GetProductAvgCount()
        {
            var values = await _httpClient.GetFromJsonAsync<decimal>("Statictis/GetProductAvgPrice");
            return values;
        }

        public async Task<long> GetProductCount()
        {
            var values = await _httpClient.GetFromJsonAsync<long>("Statictis/GetProductCount");
            return values;
        }
    }
}
