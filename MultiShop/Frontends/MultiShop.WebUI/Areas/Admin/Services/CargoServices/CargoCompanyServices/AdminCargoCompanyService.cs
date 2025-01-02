using MultiShop.DtoLayer.CargoDtos.CargoCompany;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CargoServices.CargoCompanyServices
{
    public class AdminCargoCompanyService : IAdminCargoCompanyService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public AdminCargoCompanyService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task CreateCargoCompanyAsync(CreateCargoCompanyDto cargoCompanyDto)
        {
            await _httpClient.PostAsJsonAsync("cargocompany", cargoCompanyDto);
        }

        public async Task DeleteCargoCompanyAsync(int id)
        {
            await _httpClient.DeleteAsync("CargoCompany?id=" + id);
        }

        public async Task<List<ResultCargoCompanyDto>> GetAllCargoCompanyAsync()
        {
            var response = await _httpClient.GetAsync("cargocompany");

            if(response.StatusCode == HttpStatusCode.Found)
            {
                _contextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<List<ResultCargoCompanyDto>>("cargocompany");
            return values;
        }

        public async Task<UpdateCargoCompanyDto> GetByIdCargoCompanyAsync(int id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateCargoCompanyDto>("cargocompany/" + id);
            return values;
        }

        public async Task UpdateCargoCompanyAsync(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _httpClient.PutAsJsonAsync("cargocompany", updateCargoCompanyDto);

        }
    }
}
