using MultiShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.FeatureServices
{
    public interface IAdminFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createfeatereDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updatefeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);

    }
}
