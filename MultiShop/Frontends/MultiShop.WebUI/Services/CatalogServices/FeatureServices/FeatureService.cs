using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public class FeatureService : IFeatureService
    {
        private readonly HttpClient _httpClient;

        public FeatureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createfeatereDto)
        {
            await _httpClient.PostAsJsonAsync<CreateFeatureDto>("feature", createfeatereDto);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _httpClient.DeleteAsync("feature/" + id);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
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
            await _httpClient.PutAsJsonAsync<UpdateFeatureDto>("feature", updatefeatureDto);
        }
    }
}
