using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.CategoryServices
{
    public class AdminCategoryService : IAdminCategoryService
    {
		private readonly HttpClient _httpClient;
		private readonly IHttpContextAccessor _httpContext;
		public AdminCategoryService(HttpClient httpClient, IHttpContextAccessor httpContext)
		{
			_httpClient = httpClient;
			_httpContext = httpContext;
		}

		public async Task CreateCategoryAsync(CreateCategoryDto createcategoryDto)
        {
            await _httpClient.PostAsJsonAsync("category", createcategoryDto);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _httpClient.DeleteAsync("category/" + id);
        }

        public async Task<List<ResultCategory>> GetAllCategoryAsync()
        {
            var response = await _httpClient.GetAsync("category");

			if (response.StatusCode == HttpStatusCode.Found)
			{
				_httpContext.HttpContext.Response.Redirect("/Login/Index");
				return null;
			}

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
            await _httpClient.PutAsJsonAsync("category", updatecategoryDto);
        }
    }
}
