using MultiShop.Catalog.Dtos.OfferDiscountDtos;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscount>> GetAllOfferDiscountAsync();
        Task CreateOfferDiscountAsync(CreateOfferDiscount createOfferDiscountDto);
        Task UpdateOfferDiscountAsync(UpdateOfferDiscount updateOfferDiscountDto);
        Task DeleteOfferDiscountAsync(string id);
        Task<GetByOfferDiscount> GetByIdOfferDiscountAsync(string id);
    }
}
