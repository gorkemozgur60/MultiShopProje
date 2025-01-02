using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Services.CatalogServices.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createcategoryDto)
        {
            await _httpClient.PostAsJsonAsync<CreateCategoryDto>("category",createcategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("category/"+id);
        }

        public async Task<List<ResultCategory>> GetAllCategoryAsync()
        {

            var values = await _httpClient.GetFromJsonAsync<List<ResultCategory>>("category");
            return values;

        }

        public async Task<UpdateCategoryDto> GetByIdCategoriesAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateCategoryDto>($"category/{id}");
            return values;
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updatecategoryDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateCategoryDto>("category", updatecategoryDto);
        }
    }
}
