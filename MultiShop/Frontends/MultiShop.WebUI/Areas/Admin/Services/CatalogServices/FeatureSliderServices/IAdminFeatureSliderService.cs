using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.FeatureSliderServices
{
    public interface IAdminFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeautureSliderAsync();
        Task CreateFeautureSliderAsync(CreateFeatureSliderDto createfeauteSliderDto);
        Task UpdateFeautureSliderAsync(UpdateFeatureSliderDto updatefeautureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChageStatusToTrue(string id);
        Task FeatureSliderChageStatusToFalse(string id);

    }
}
