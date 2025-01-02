using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.AboutServices
{
    public class AdminAboutService : IAdminAboutService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;

        public AdminAboutService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
        }

        public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
        {
            await _httpClient.PostAsJsonAsync("about", createAboutDto);
        }

        public async Task DeleteAboutAsync(string id)
        {
            await _httpClient.DeleteAsync("about/" + id);
        }

        public async Task<List<ResultAboutDto>> GetAllAboutAsync()
        {
            var response = await _httpClient.GetAsync("about");

            if(response.StatusCode == HttpStatusCode.Found)
            {
                _contextAccessor.HttpContext.Response.Redirect("Admin/AdminLoginPanel/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<List<ResultAboutDto>>("about");
            return values;
        }

        public async Task<UpdateAboutDto> GetByIdAboutAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateAboutDto>("about/" + id);
            return values;
        }

        public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            await _httpClient.PutAsJsonAsync("about", updateAboutDto);
        }
    }
}
