using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code)
        {
            var values = await _httpClient.GetFromJsonAsync<GetDiscountCodeDetailByCode>("discount/GetCodeDetailByCode?code="+code);
            return values;
        }

        public async Task<int> GetDiscountCouponCountRate(string code)
        {
            var values = await _httpClient.GetFromJsonAsync<int>("discount/GetDiscountCouponCountRate?code=" + code);
            return values;
        }
    }
}
