using MultiShop.Catalog.Dtos.AboutDtos;

namespace MultiShop.Catalog.Services.AboutServices
{
    public interface IAboutService
    {
        Task<List<ResultAbout>> GetAllAboutAsync();
        Task CreateAboutAsync(CreateAbout createAboutDto);
        Task UpdateAboutAsync(UpdateAbout updateAboutDto);
        Task DeleteAboutAsync(string id);
        Task<GetByAbout> GetByIdAboutAsync(string id);
    }
}
