using MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.OrderServices.OrderAddressServices
{
    public class AdminOrderAddressService : IAdminOrderAddressService
    {
        private readonly HttpClient _httpClient;

        public AdminOrderAddressService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto)
        {
            await _httpClient.PostAsJsonAsync("address", createOrderAddressDto);
        }
    }
}
