
using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createfeatereDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updatefeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);

    }
}
