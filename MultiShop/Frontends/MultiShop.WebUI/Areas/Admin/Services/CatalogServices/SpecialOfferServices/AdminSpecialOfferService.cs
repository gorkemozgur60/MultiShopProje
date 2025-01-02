using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using System.Net;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.SpecialOfferServices
{
    public class AdminSpecialOfferService : IAdminSpecialOfferService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AdminSpecialOfferService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _httpClient.PostAsJsonAsync("specialoffer", createSpecialOfferDto);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _httpClient.DeleteAsync("specialoffer/" + id);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var response = await _httpClient.GetAsync("featureslider");
            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }
            var values = await _httpClient.GetFromJsonAsync<List<ResultSpecialOfferDto>>("specialoffer");
            return values;
        }

        public async Task<UpdateSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateSpecialOfferDto>("specialoffer/" + id);
            return values;
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _httpClient.PutAsJsonAsync("specialoffer", updateSpecialOfferDto);
        }
    }
}
