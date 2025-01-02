namespace MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices
{
    public class DiscountStatisticServices : IDiscountStatisticServices
    {
        private readonly HttpClient _httpClient;

        public DiscountStatisticServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetDiscountCouponCount()
        {
            var values = await _httpClient.GetFromJsonAsync<int>("discount/getdiscountcouponcount");
            return values;
        }
    }
}
