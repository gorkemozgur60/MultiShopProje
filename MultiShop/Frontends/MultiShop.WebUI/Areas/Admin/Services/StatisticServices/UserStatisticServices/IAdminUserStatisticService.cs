namespace MultiShop.WebUI.Areas.Admin.Services.StatisticServices.UserStatisticServices
{
    public interface IAdminUserStatisticService
    {
        Task<int?> GetAllUserCount();
    }
}
