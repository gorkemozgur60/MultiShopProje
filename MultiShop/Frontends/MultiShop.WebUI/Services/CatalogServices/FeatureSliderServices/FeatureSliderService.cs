using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public class FeatureSliderService : IFeatureSliderService
    {
        private readonly HttpClient _httpClient;

        public FeatureSliderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeautureSliderAsync(CreateFeatureSliderDto createfeauteSliderDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureSliderDto>("featureslider", createfeauteSliderDto);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await _httpClient.DeleteAsync("featureslider/" + id);
        }

        public  Task FeatureSliderChageStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChageStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeautureSliderAsync()
        {
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
            await _httpClient.PutAsJsonAsync<UpdateFeatureSliderDto>("featureslider", updatefeautureSliderDto);
        }
    }
}
