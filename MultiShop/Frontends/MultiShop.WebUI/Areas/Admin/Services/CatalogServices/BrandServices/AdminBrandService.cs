using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using System.Net;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.BrandServices
{
    public class AdminBrandService : IAdminBrandService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminBrandService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync("brand", createBrandDto);

        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("brand/" + id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var response = await _httpClient.GetAsync("about");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("Admin/AdminLoginPanel/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<List<ResultBrandDto>>("brand");
            return values;
        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateBrandDto>("brand/" + id);
            return values;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync("brand", updateBrandDto);
        }
    }
}
