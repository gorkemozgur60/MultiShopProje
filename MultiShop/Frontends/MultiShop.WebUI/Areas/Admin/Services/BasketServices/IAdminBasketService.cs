using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.BasketServices
{
    public interface IAdminBasketService
    {
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasket(string productId);
        Task<BasketTotalDto> GetBasket();
        Task SaveBasket(BasketTotalDto basket);
        Task DeleteBasket(string UserId);
    }
}
