using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderOrderingServices
{
    public class AdminOrderOrderingService : IAdminOrderOrderingService
    {
        private readonly HttpClient _httpClient;

        public AdminOrderOrderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultOrderingByUserIdDto>>("orderings/GetOrderingByUserId/" + id);
            return values;
        }
    }
}
