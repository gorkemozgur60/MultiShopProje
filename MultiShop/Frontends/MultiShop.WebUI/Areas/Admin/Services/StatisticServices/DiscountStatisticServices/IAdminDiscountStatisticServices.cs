namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.DiscountStatisticServices
{
    public interface IAdminDiscountStatisticServices
    {
        Task<int?> GetDiscountCouponCount();
    }
}
