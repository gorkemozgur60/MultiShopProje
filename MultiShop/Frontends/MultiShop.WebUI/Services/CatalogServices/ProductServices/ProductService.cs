using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync<CreateProductDto>("product",createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("product/"+id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("product");
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateProductDto>("product/"+id);
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("product/productlistwithcategory");
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByIdAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("product/productListwithcategorybyid/"+id);
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDto>("product", updateProductDto);
        }
    }
}
