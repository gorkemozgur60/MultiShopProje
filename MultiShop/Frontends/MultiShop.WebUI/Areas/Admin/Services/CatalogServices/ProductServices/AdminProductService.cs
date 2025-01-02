using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using System.Net;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductServices
{
    public class AdminProductService : IAdminProductService
	{
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminProductService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await _httpClient.PostAsJsonAsync("product", createProductDto);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _httpClient.DeleteAsync("product/" + id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductDto>>("product");
            return values;
        }

        public async Task<UpdateProductDto> GetByIdProductAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateProductDto>("product/" + id);
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var response = await _httpClient.GetAsync("featureslider");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("product/productlistwithcategory");
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByIdAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductWithCategoryDto>>("product/productListwithcategorybyid/" + id);
            return values;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await _httpClient.PutAsJsonAsync("product", updateProductDto);
        }
    }
}
