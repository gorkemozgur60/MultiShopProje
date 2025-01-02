

using MultiShop.Catalog.Entities;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly HttpClient _httpClient;

        public ProductImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductImageDto>("productimage", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimage/"+id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>("productimage");
            return values;
        }

        public async Task<GetByProductImageDto> GetByIdProductImageAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<GetByProductImageDto>("productimage/"+id);
            return values;
        }

        public async Task<UpdateProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateProductImageDto>("productimage/productimagebyproductid/" + id);
            
            return values;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductImageDto>("productimage",updateProductImageDto);
        }

    }
}
