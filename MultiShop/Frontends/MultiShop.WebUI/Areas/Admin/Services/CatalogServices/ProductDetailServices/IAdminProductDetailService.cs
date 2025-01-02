using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;


namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductDetailServices
{
    public interface IAdminProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task<HttpResponseMessage> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByProductDetailDto> GetByIdProductDetailAsync(string id);
        Task<GetByProductDetailDto> GetByProductIdProductDetailAsync(string id);

    }
}
