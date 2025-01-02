using MultiShop.DtoLayer.DiscountDtos;

namespace MultiShop.WebUI.Areas.Admin.Services.DiscountServices
{
    public interface IAdminDiscountService
    {
        public Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
        Task<int> GetDiscountCouponCountRate(string code);
    }
}
