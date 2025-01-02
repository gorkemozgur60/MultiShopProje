using MultiShop.Catalog.Dtos.SpecialOfferDtos;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOffer>> GetAllSpecialOfferAsync();
        Task CreateSpecialOfferAsync(CreateSpecialOffer createSpecialOfferDto);
        Task UpdateSpecialOfferAsync(UpdateSpecialOffer updateSpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);
        Task<GetBySpecialOffer> GetByIdSpecialOfferAsync(string id);
    }
}
