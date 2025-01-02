using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.FeatureSliderServices
{
    public class AdminFeatureSliderService : IAdminFeatureSliderService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminFeatureSliderService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateFeautureSliderAsync(CreateFeatureSliderDto createfeauteSliderDto)
        {
            await _httpClient.PostAsJsonAsync("featureslider", createfeauteSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featureslider/" + id);
        }

        public Task FeatureSliderChageStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChageStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeautureSliderAsync()
        {
            var response = await _httpClient.GetAsync("featureslider");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }
            var values = await _httpClient.GetFromJsonAsync<List<ResultFeatureSliderDto>>("featureslider");
            return values;
        }

        public async Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateFeatureSliderDto>("featureslider/" + id);
            return values;
        }

        public async Task UpdateFeautureSliderAsync(UpdateFeatureSliderDto updatefeautureSliderDto)
        {
            await _httpClient.PutAsJsonAsync("featureslider", updatefeautureSliderDto);
        }
    }
}
