using MultiShop.Catalog.Dtos.FeatureDtos;

namespace MultiShop.Catalog.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeature>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeature createfeatereDto);
        Task UpdateFeatureAsync(UpdateFeature updatefeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<GetByFeature> GetByIdFeatureAsync(string id);

    }
}
