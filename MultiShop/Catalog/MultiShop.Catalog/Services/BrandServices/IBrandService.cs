using MultiShop.Catalog.Dtos.BrandDtos;

namespace MultiShop.Catalog.Services.BrandServices
{
    public interface IBrandService
    {
        Task<List<ResultBrand>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrand createBrandDto);
        Task UpdateBrandAsync(UpdateBrand updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<GetByBrand> GetByIdBrandAsync(string id);
    }
}
