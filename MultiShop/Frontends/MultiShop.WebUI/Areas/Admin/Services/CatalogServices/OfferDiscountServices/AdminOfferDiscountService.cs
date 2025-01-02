using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using System.Net;
using System.Net.Http.Json;

namespace MultiShop.WebUI.Areas.Admin.Services.CatalogServices.OfferDiscountServices
{
    public class AdminOfferDiscountService : IAdminOfferDiscountService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminOfferDiscountService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
        {
            await _httpClient.PostAsJsonAsync("offerdiscount", createOfferDiscountDto);
        }

        public async Task DeleteOfferDiscountAsync(string id)
        {
            await _httpClient.DeleteAsync("offerdiscount/" + id);
        }

        public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
        {
            var response = await _httpClient.GetAsync("offerdiscount");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContextAccessor.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<List<ResultOfferDiscountDto>>("offerdiscount");
            return values;
        }

        public async Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
        {
            var values = await _httpClient.GetFromJsonAsync<UpdateOfferDiscountDto>("offerdiscount/" + id);
            return values;
        }

        public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            await _httpClient.PutAsJsonAsync("offerdiscount", updateOfferDiscountDto);
        }
    }
}
