using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.ProductDetailServices
{
    public class AdminProductDetailService : IAdminProductDetailService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminProductDetailService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync("productdetail", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetail/" + id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultProductDetailDto>>("productdetail");
            return values;
        }

        public async Task<GetByProductDetailDto> GetByIdProductDetailAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<GetByProductDetailDto>("productdetail/" + id);
            return values;
        }

        public async Task<GetByProductDetailDto> GetByProductIdProductDetailAsync(string id)
        {
            var response = await _httpClient.GetAsync("productdetail/getproductdetailbyproductid/" + id);

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<GetByProductDetailDto>("productdetail/getproductdetailbyproductid/" + id);
            return values;
        }

        public async Task<HttpResponseMessage> UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var values = await _httpClient.PutAsJsonAsync("productdetail", updateProductDetailDto);
            return values;
        }
    }
}
