using MultiShop.DtoLayer.BasketDtos;
using System.Net;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContext;
        public BasketService(HttpClient httpClient, IHttpContextAccessor httpContext)
        {
            _httpClient = httpClient;
            _httpContext = httpContext;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if(values != null)
            {
                if(!values.BasketItems.Any(x=> x.ProductId == basketItemDto.ProductId))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else
                {
                    values = await GetBasket();
                    values.BasketItems.Add(basketItemDto);
                }
            }
            await SaveBasket(values);
        }

        public Task DeleteBasket(string UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var response = await _httpClient.GetAsync("basket");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                _httpContext.HttpContext.Response.Redirect("/Login/Index");
                return null;
            }

            var values = await _httpClient.GetFromJsonAsync<BasketTotalDto>("basket");
            return values;
        }

        public async Task<bool> RemoveBasket(string productId)
        {
            var values = await GetBasket();
            var deletedItem= values.BasketItems.FirstOrDefault(x => x.ProductId == productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basket)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("basket", basket);
        }
    }
}
