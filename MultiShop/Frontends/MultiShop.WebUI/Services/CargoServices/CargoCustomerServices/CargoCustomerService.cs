using MultiShop.DtoLayer.CargoDtos.CargoCustomer;

namespace MultiShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public class CargoCustomerService : ICargoCustomerService
    {
        private readonly HttpClient _httpClient;

        public CargoCustomerService(HttpClient httpClient)
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
