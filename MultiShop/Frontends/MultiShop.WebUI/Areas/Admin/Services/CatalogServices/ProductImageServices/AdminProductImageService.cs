using MultiShop.Catalog.Entities;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductImageServices
{
    public class AdminProductImageService : IAdminProductImageService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminProductImageService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _httpClient.PostAsJsonAsync("productimage", createProductImageDto);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _httpClient.DeleteAsync("productimage/" + id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductImageDto>>("productimage");
            return values;
        }

        public async Task<GetByProductImageDto> GetByIdProductImageAsync(string id)
        {
            var response = await _httpClient.GetAsync("featureslider");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }
            var values = await _httpClient.GetFromJsonAsync<GetByProductImageDto>("productimage/" + id);
            return values;
        }

        public async Task<UpdateProductImageDto> GetByProductIdProductImageAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateProductImageDto>("productimage/productimagebyproductid/" + id);

            return values;
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _httpClient.PutAsJsonAsync("productimage", updateProductImageDto);
        }

    }
}
