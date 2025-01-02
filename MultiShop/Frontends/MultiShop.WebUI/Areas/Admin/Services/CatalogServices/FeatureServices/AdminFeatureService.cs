using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.FeatureServices
{
    public class AdminFeatureService : IAdminFeatureService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminFeatureService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createfeatereDto)
        {
            await _httpClient.PostAsJsonAsync("feature", createfeatereDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("feature/" + id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var response = await _httpClient.GetAsync("feature");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<List<ResultFeatureDto>>("feature");
            return values;
        }

        public async Task<UpdateFeatureDto> GetByIdFeatureAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateFeatureDto>("feature/" + id);
            return values;
        }

        public async Task UpdateFeatureAsync(UpdateFeatureDto updatefeatureDto)
        {
            await _httpClient.PutAsJsonAsync("feature", updatefeatureDto);
        }
    }
}
