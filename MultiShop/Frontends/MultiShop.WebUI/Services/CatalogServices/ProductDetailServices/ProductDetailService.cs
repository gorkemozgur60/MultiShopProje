using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace MultiShop.WebUI.Services.CatalogServices.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly HttpClient _httpClient;

        public ProductDetailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<CreateProductDetailDto>("productdetail", createProductDetailDto);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _httpClient.DeleteAsync("productdetail/"+id);
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
            var values = await _httpClient.GetFromJsonAsync<GetByProductDetailDto>("productdetail/getproductdetailbyproductid/" + id);
            return values;
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateProductDetailDto>("productdetail", updateProductDetailDto);
        }
    }
}
