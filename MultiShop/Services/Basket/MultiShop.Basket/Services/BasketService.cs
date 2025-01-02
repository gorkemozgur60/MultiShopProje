using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string UserId)
        {
            await _redisService.GetDb().KeyDeleteAsync(UserId);
        }

        public async Task<BasketTotalDto> GetBasket(string UserId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(UserId);

            if (string.IsNullOrEmpty(existBasket))
            {
                var newBasket = new BasketTotalDto
                {
                    BasketItems = new List<BasketItemDto>(),
                    UserId = UserId,
                    DiscountCode = "",
                    DiscountRate = 0
                };
                var basketJson = JsonSerializer.Serialize(newBasket);
                await _redisService.GetDb().StringSetAsync(UserId, basketJson);
                
                return newBasket;
            }

            var basket = JsonSerializer.Deserialize<BasketTotalDto>(existBasket);

            if (basket == null)
            {
                return new BasketTotalDto
                {
                    BasketItems = new List<BasketItemDto>(),
                    UserId = UserId,
                    DiscountCode = "",
                    DiscountRate = 0
                };
            }

            return basket;
        }

        public async Task SaveBasket(BasketTotalDto basket)
        {
            await _redisService.GetDb().StringSetAsync(basket.UserId,JsonSerializer.Serialize(basket));
        }
    }
}
