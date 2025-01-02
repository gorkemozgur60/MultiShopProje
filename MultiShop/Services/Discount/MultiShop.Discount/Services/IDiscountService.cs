using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService 
    {
        Task<List<ResultCoupon>> GetAllCouponsAsync();
        Task CreateCouponAsync (CreateCoupon createCoupon);
        Task UpdateCouponAsync (UpdateCoupon updateCoupon);
        Task DeleteCouponAsync (int id);
        Task<GetByIdCoupon> GetByIdCouponAsync (int id);
        Task<ResultCoupon> GetCodeDetailByCode (string code);
        int GetDiscountCouponCountRate(string code);
        Task<int> GetDiscountCouponCount();
    }
}
