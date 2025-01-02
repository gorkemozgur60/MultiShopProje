using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasket(string productId);
        Task<BasketTotalDto> GetBasket();
        Task SaveBasket(BasketTotalDto basket);
        Task DeleteBasket(string UserId);
    }
}
