using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        public Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
        Task<int> GetDiscountCouponCountRate(string code);
    }
}
