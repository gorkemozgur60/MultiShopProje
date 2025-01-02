using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSlider>> GetAllFeautureSliderAsync();
        Task CreateFeautureSliderAsync(CreateFeatureSlider createfeauteSliderDto);
        Task UpdateFeautureSliderAsync(UpdateFeatureSlider updatefeautureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<GetByFeautureSlider> GetByIdFeatureSliderAsync(string id);
        Task FeatureSliderChageStatusToTrue(string  id);
        Task FeatureSliderChageStatusToFalse(string id);

    }
}
