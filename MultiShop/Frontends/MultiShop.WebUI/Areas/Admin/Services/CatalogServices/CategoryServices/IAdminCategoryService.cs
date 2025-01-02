using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.CategoryServices
{
    public interface IAdminCategoryService
    {
        Task<List<ResultCategory>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createcategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updatecategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<UpdateCategoryDto> GetByIdCategoriesAsync(string id);
    }
}
