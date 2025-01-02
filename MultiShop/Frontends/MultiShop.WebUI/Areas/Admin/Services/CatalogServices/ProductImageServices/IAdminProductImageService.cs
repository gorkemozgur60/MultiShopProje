using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductImageServices
{
    public interface IAdminProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByProductImageDto> GetByIdProductImageAsync(string id);
        Task<UpdateProductImageDto> GetByProductIdProductImageAsync(string id);
    }
}
