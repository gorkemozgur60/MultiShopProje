using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;


namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<GetByProductDetailDto> GetByProductIdProductDetailAsync(string id);

    }
}
