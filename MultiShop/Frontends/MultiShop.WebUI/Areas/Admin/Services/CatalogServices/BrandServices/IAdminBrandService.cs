using MultiShop.DtoLayer.CatalogDtos.BrandDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.BrandServices
{
    public interface IAdminBrandService
    {
        Task<List<ResultBrandDto>> GetAllBrandAsync();
        Task CreateBrandAsync(CreateBrandDto createBrandDto);
        Task UpdateBrandAsync(UpdateBrandDto updateBrandDto);
        Task DeleteBrandAsync(string id);
        Task<UpdateBrandDto> GetByIdBrandAsync(string id);
    }
}
