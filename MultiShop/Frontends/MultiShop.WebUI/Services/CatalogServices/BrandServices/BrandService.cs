using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Services.CatalogServices.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly HttpClient _httpClient;

        public BrandService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            await _httpClient.PostAsJsonAsync<CreateBrandDto>("brand", createBrandDto);

        }

        public async Task DeleteBrandAsync(string id)
        {
            await _httpClient.DeleteAsync("brand/" + id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _httpClient.GetFromJsonAsync<List<ResultBrandDto>>("brand");
            return values;
        }

        public async Task<UpdateBrandDto> GetByIdBrandAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateBrandDto>("brand/"+id);
            return values;
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateBrandDto>("brand", updateBrandDto);
        }
    }
}
