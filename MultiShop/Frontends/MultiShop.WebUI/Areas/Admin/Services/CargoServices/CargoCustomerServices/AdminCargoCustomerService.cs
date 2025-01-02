using MultiShop.DtoLayer.CargoDtos.CargoCustomer;

namespace MultiShop.WebUI.Areas.Admin.Services.CargoServices.CargoCustomerServices
{
    public class AdminCargoCustomerService : IAdminCargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public AdminCargoCustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetCargoCustomerDto> GetByIdCargoCustomerInfoAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<GetCargoCustomerDto>("cargoCustomer/getcargocustomerbyid?id=" + id);
            return values;
        }
    }
}
