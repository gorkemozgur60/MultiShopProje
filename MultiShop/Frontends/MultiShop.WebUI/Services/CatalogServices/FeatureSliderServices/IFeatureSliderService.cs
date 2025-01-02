
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeautureSliderAsync();
        Task CreateFeautureSliderAsync(CreateFeatureSliderDto createfeauteSliderDto);
        Task UpdateFeautureSliderAsync(UpdateFeatureSliderDto updatefeautureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChageStatusToTrue(string  id);
        Task FeatureSliderChageStatusToFalse(string id);

    }
}
