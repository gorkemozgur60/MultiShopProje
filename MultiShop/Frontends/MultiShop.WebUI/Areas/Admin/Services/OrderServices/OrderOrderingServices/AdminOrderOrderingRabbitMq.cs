using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderOrderingServices
{
    public class AdminOrderOrderingRabbitMq : IAdminOrderOrderingRabbitMq
    {
        private readonly HttpClient _httpClient;

        public AdminOrderOrderingRabbitMq(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultOrderingByUserIdDto>> GetAllOrder()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultOrderingByUserIdDto>>("orderings/GetAllOrder");
            return values;
        }

        public async Task<GetOrderDetailsResult> GetOrderDetailByOrderId(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<GetOrderDetailsResult>("OrderDetails/GetOrderDetailByOrderId/" + id);
            return values;
        }
    }
}
